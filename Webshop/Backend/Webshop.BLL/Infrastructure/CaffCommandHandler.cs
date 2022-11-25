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
        private readonly IWebshopConfigurationService _galleryConfiguration;
        private readonly IMapper _mapper;
        private IValidator? _validator;

        public CaffCommandHandler(
            IUnitOfWork unitOfWork, 
            IFileRepository fileRepository,
            IWebshopConfigurationService galleryConfiguration,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _fileRepository = fileRepository;
            _galleryConfiguration = galleryConfiguration;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var commentEntity = _unitOfWork.CommentRepository.GetByID(request.Dto.CommentId);
            _unitOfWork.CommentRepository.Delete(commentEntity);
            await _unitOfWork.Save();
            return Unit.Value;
        }

        public async Task<Unit> Handle(PostCommentCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(request.User.GetUserIdFromJwt());
            var user = _unitOfWork.UserRepository.Get(x => x.Id == userId).First();
            var commentedCaff = _unitOfWork.CaffRepository.Get(x => x.Id == request.CaffId, includeProperties: nameof(Caff.Comments)).First();
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
            var caffEntity = _mapper.Map<Caff>(request.Dto);
            var userId = Guid.Parse(request.User.GetUserIdFromJwt());
            var user = _unitOfWork.UserRepository.GetByID(userId);

            IList<Ciff> ciffs = new List<Ciff>();
            foreach (var uploadedFile in request.Dto.Caffs)
            {
                var filePath = Path.GetTempFileName();
                var sanitizedFilename = _fileRepository.SanitizeFilename(uploadedFile.FileName);
                var extension = Path.GetExtension(sanitizedFilename);
                using (var stream = File.Create(filePath))
                {
                    await uploadedFile.CopyToAsync(stream);
                }
                var savedPicture = _fileRepository.SaveFile(userId, filePath, extension);
                ciffs.Add(savedPicture);
            }
            caffEntity.Uploader = user;
            caffEntity.Ciffs = ciffs;
            _unitOfWork.CaffRepository.Insert(caffEntity);
            await _unitOfWork.Save();
            return caffEntity.Id;
        }

        public async Task<Unit> Handle(DeleteCaffCommand request, CancellationToken cancellationToken)
        {
            var caffEntity = _unitOfWork.CaffRepository.Get(
                filter: x => x.Id == request.CaffId, 
                includeProperties: string.Join(',', nameof(Caff.Uploader), nameof(Caff.Ciffs))
                ).First();

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
            var caffEntity = _unitOfWork.CaffRepository.Get(x => x.Id == request.CaffId, includeProperties: nameof(Caff.BoughtBy)).First();
            var buyer = _unitOfWork.UserRepository.GetByID(userId);
            if (caffEntity.BoughtBy != null)
            {
                throw new Exception("Already sold");
            }
            caffEntity.BoughtBy = buyer;
            _unitOfWork.CaffRepository.Update(caffEntity);
            await _unitOfWork.Save();
            return Unit.Value;
        }

        public async Task<Unit> Handle(EditCaffDataCommand request, CancellationToken cancellationToken)
        {
            var caffEntity = _unitOfWork.CaffRepository.Get(filter: x => x.Id == request.CaffId, includeProperties: nameof(Caff.Uploader)).FirstOrDefault();
            if (caffEntity == null)
            {
                throw new EntityNotFoundException("Caff file not found");
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
