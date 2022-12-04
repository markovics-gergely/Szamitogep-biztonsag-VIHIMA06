using AutoMapper;
using Webshop.BLL.Exceptions;
using Webshop.BLL.Extensions;
using Webshop.BLL.Infrastructure.Commands;
using Webshop.BLL.Validators.Implementations;
using Webshop.BLL.Validators.Interfaces;
using Webshop.DAL.Configurations;
using Webshop.DAL.Configurations.Interfaces;
using Webshop.DAL.Domain;
using Webshop.DAL.Repository.Interfaces;
using Webshop.DAL.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Webshop.DAL.Migrations;

namespace Webshop.BLL.Infrastructure
{
    public class CaffCommandHandler :
        IRequestHandler<RemoveCommentCommand, Unit>,
        IRequestHandler<PostCommentCommand, Unit>,
        IRequestHandler<UploadCaffCommand, Guid>,
        IRequestHandler<DeleteCaffCommand, Unit>,
        IRequestHandler<BuyCaffCommand, Unit>,
        IRequestHandler<EditCaffDataCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileRepository _fileRepository;
        private readonly IWebshopConfigurationService _webshopConfiguration;
        private readonly IMapper _mapper;
        private IValidator? _validator;

        [DllImport("CaffParser.dll", CharSet = CharSet.Ansi)]
        static extern int readCaff([In] StringBuilder inPath, [In] StringBuilder caffName, [In] StringBuilder outPath, [In, Out] ref int ciffCount);

        public CaffCommandHandler(
            IUnitOfWork unitOfWork, 
            IFileRepository fileRepository,
            IWebshopConfigurationService webshopConfiguration,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _fileRepository = fileRepository;
            _webshopConfiguration = webshopConfiguration;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var commentEntity = _unitOfWork.CommentRepository.Get(
                filter: x => x.Id == request.Dto.CommentId,
                includeProperties: $"{nameof(Comment.CommentedCaff)}.{nameof(Caff.Uploader)}").FirstOrDefault();
            if (commentEntity == null)
            {
                throw new EntityNotFoundException("Requested entity not found");
            }

            _validator = new AndCondition(
                new AvailabilityValidator(commentEntity.CommentedCaff), 
                new OrCondition(
                    new AdminUserValidator(request.User),
                    new UploaderValidator(commentEntity.CommentedCaff, request.User)
                ));
            if (!_validator.Validate())
            {
                throw new ValidationErrorException("Validation error occured");
            }
            _unitOfWork.CommentRepository.Delete(commentEntity);
            await _unitOfWork.Save();
            return Unit.Value;
        }

        public async Task<Unit> Handle(PostCommentCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(request.User.GetUserIdFromJwt());
            var user = _unitOfWork.UserRepository.Get(x => x.Id == userId).First();
            var commentedCaff = _unitOfWork.CaffRepository.Get(x => x.Id == request.CaffId, includeProperties: nameof(Caff.Comments)).FirstOrDefault();
            if (commentedCaff == null)
            {
                throw new EntityNotFoundException("Requested entity not found");
            }
            _validator = new AvailabilityValidator(commentedCaff);
            if (!_validator.Validate())
            {
                throw new ValidationErrorException("Validation error occured");
            }

            var comment = new Comment
            {
                Text = request.Dto.Text,
                CommentedCaff = commentedCaff,
                Commenter = user
            };
            commentedCaff.Comments.Add(comment);
            _unitOfWork.CaffRepository.Update(commentedCaff);
            await _unitOfWork.Save();
            return Unit.Value;
        }

        public async Task<Guid> Handle(UploadCaffCommand request, CancellationToken cancellationToken)
        {
            var sanitizedFilename = _fileRepository.SanitizeFilename(request.Dto.Caff.FileName);
            var extension = Path.GetExtension(sanitizedFilename);
            if (extension.ToLower() != ".caff")
            {
                throw new ValidationErrorException("Only CAFF files are accepted");
            }

            string caffPath = Path.ChangeExtension(Path.Combine(_webshopConfiguration.GetStaticFilePhysicalPath(),
                _webshopConfiguration.GetCaffsSubdirectory(), Path.GetRandomFileName()), ".caff");

            if (!Directory.Exists(caffPath))
            {
                Directory.CreateDirectory(caffPath);
            }

            using (var stream = File.Create(caffPath))
            {
                await request.Dto.Caff.CopyToAsync(stream, cancellationToken);
            }

            int ciffCount = 0;
            string metaPath = $"{_webshopConfiguration.GetStaticFilePhysicalPath()}\\{_webshopConfiguration.GetCaffMetaSubdirectory()}\\";
            var result = readCaff(new StringBuilder(Path.GetDirectoryName(caffPath)), new StringBuilder(Path.GetFileNameWithoutExtension(caffPath)), new StringBuilder(metaPath), ref ciffCount);
            if (result != 0)
            {
                File.Delete(caffPath);
                throw new ValidationErrorException("Validation error");
            }

            var caffEntity = _fileRepository.ReadMetadata(metaPath, Path.GetFileNameWithoutExtension(caffPath), ciffCount);
            for (int i = 0; i < ciffCount; i++)
            {
                var ciffName = $"{Path.GetFileNameWithoutExtension(caffPath)}_{i}.bmp";
                var ciffSavedPath = _fileRepository.SaveFile(Path.Combine(metaPath, ciffName), ".bmp", $"\\{_webshopConfiguration.GetImagesSubdirectory()}");
                caffEntity.Ciffs[i].PhysicalPath = ciffSavedPath;
                caffEntity.Ciffs[i].DisplayPath = $"/{Path.GetFileName(ciffSavedPath)}";
            }
            var userId = Guid.Parse(request.User.GetUserIdFromJwt());
            var user = _unitOfWork.UserRepository.GetByID(userId);

            caffEntity.Price = 0;
            caffEntity.Title = request.Dto.Title;
            caffEntity.Description = request.Dto.Description;
            caffEntity.Uploader = user;
            caffEntity.PhysicalPath = caffPath;
            _unitOfWork.CaffRepository.Insert(caffEntity);
            await _unitOfWork.Save();
            return caffEntity.Id;
        }

        public async Task<Unit> Handle(DeleteCaffCommand request, CancellationToken cancellationToken)
        {
            var caffEntity = _unitOfWork.CaffRepository.Get(
                filter: x => x.Id == request.CaffId, 
                includeProperties: string.Join(',', nameof(Caff.Uploader), nameof(Caff.Ciffs))
                ).FirstOrDefault();

            if (caffEntity == null)
            {
                throw new EntityNotFoundException("Requested entity not found");
            }

            _validator = new AndCondition(
                new AvailabilityValidator(caffEntity),
                new OrCondition(
                    new AdminUserValidator(request.User),
                    new UploaderValidator(caffEntity, request.User)
                    )
                );
            if (!_validator.Validate())
            {
                throw new ValidationErrorException("Validation error occured");
            }

            _unitOfWork.CaffRepository.Delete(caffEntity);
            foreach (var ciff in caffEntity.Ciffs)
            {
                _fileRepository.DeleteFile(ciff.PhysicalPath);
            }
            await _unitOfWork.Save();
            return Unit.Value;
        }

        public async Task<Unit> Handle(BuyCaffCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(request.User.GetUserIdFromJwt());
            var caffEntity = _unitOfWork.CaffRepository.Get(x => x.Id == request.CaffId, includeProperties: nameof(Caff.BoughtBy)).FirstOrDefault();
            if (caffEntity == null)
            {
                throw new EntityNotFoundException("Requested entity not found");
            }
            _validator = new AvailabilityValidator(caffEntity);
            if (!_validator.Validate())
            {
                throw new ValidationErrorException("ValidationErrorOccured");
            }
            var buyer = _unitOfWork.UserRepository.GetByID(userId);
            caffEntity.BoughtBy = buyer;
            _unitOfWork.CaffRepository.Update(caffEntity);
            await _unitOfWork.Save();
            return Unit.Value;
        }

        public async Task<Unit> Handle(EditCaffDataCommand request, CancellationToken cancellationToken)
        {
            var caffEntity = _unitOfWork.CaffRepository.Get(filter: x => x.Id == request.CaffId, 
                includeProperties: string.Join(',', nameof(Caff.Uploader), nameof(Caff.BoughtBy))).FirstOrDefault();
            if (caffEntity == null)
            {
                throw new EntityNotFoundException("Caff file not found");
            }

            _validator = new AndCondition(
                new AvailabilityValidator(caffEntity),
                new OrCondition(
                    new AdminUserValidator(request.User),
                    new UploaderValidator(caffEntity, request.User)
                    )
                );
            if (!_validator.Validate())
            {
                throw new ValidationErrorException("Validation error occured");
            }
            if (!string.IsNullOrEmpty(request.Dto.Title))
            {
                caffEntity.Title = request.Dto.Title;
            }
            if (!string.IsNullOrEmpty(request.Dto.Description))
            {
                caffEntity.Description = request.Dto.Description;
            }

            _unitOfWork.CaffRepository.Update(caffEntity);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
