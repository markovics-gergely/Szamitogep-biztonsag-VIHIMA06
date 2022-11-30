using AutoMapper;
using Webshop.BLL.Exceptions;
using Webshop.BLL.Extensions;
using Webshop.BLL.Infrastructure.Commands;
using Webshop.BLL.Infrastructure.Queries;
using Webshop.BLL.Infrastructure.ViewModels;
using Webshop.BLL.Validators.Implementations;
using Webshop.BLL.Validators.Interfaces;
using Webshop.DAL.Domain;
using Webshop.DAL.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.Infrastructure
{
    public class CaffQueryHandler :
        IRequestHandler<GetCaffDownloadQuery, byte[]>,
        IRequestHandler<GetCaffDetailsQuery, CaffDetailsViewModel>,
        IRequestHandler<GetCaffListQuery, EnumerableWithTotalViewModel<CaffListViewModel>>,
        IRequestHandler<GetBoughtCaffsQuery, EnumerableWithTotalViewModel<CaffListViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator? _validator;

        public CaffQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CaffDetailsViewModel> Handle(GetCaffDetailsQuery request, CancellationToken cancellationToken)
        {
            var caffEntity = _unitOfWork.CaffRepository.Get(
                filter: x => x.Id == request.CaffId,
                transform: x => x.AsNoTracking(),
                includeProperties: string.Join(',', nameof(Caff.Uploader), nameof(Caff.Ciffs), nameof(Caff.Comments), nameof(Caff.BoughtBy)))
                .FirstOrDefault();
            if (caffEntity == null)
            {
                throw new EntityNotFoundException("Requested caff not found");
            }

            _validator = new OrCondition(
                new AvailabilityValidator(caffEntity),
                new OwnershipValidator(caffEntity, request.User)
                );
            if (!_validator.Validate())
            {
                throw new ValidationErrorException("Validation error occured");
            }

            var caffViewModel = _mapper.Map<CaffDetailsViewModel>(caffEntity);
            return Task.FromResult(caffViewModel);
        }

        public Task<EnumerableWithTotalViewModel<CaffListViewModel>> Handle(GetCaffListQuery request, CancellationToken cancellationToken)
        {
            var caffEntities = _unitOfWork.CaffRepository.Get(
                filter: x => x.BoughtBy == null,
                transform: x => x.AsNoTracking(),
                includeProperties: string.Join(',', nameof(Caff.Uploader), nameof(Caff.Ciffs))
                ).ToList();

            var caffViewModelWithCount = _mapper.Map<EnumerableWithTotalViewModel<CaffListViewModel>>(caffEntities);
            caffViewModelWithCount.Values = caffViewModelWithCount.Values.Skip((request.Dto.PageCount - 1) * request.Dto.PageSize).Take(request.Dto.PageSize);
            return Task.FromResult(caffViewModelWithCount);
        }

        public Task<EnumerableWithTotalViewModel<CaffListViewModel>> Handle(GetBoughtCaffsQuery request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(request.User.GetUserIdFromJwt());
            var userEntity = _unitOfWork.UserRepository.Get(
                filter: x => x.Id == userId,
                transform: x => x.AsNoTracking(),
                includeProperties: string.Join(',', $"{nameof(ApplicationUser.BoughtCaffs)}.{nameof(Caff.Ciffs)}", $"{nameof(ApplicationUser.BoughtCaffs)}.{nameof(Caff.Uploader)}")
                ).FirstOrDefault();
            if (userEntity == null)
            {
                throw new EntityNotFoundException("Requested caff not found");
            }
            var caffViewModelWithCount = _mapper.Map<EnumerableWithTotalViewModel<CaffListViewModel>>(userEntity.BoughtCaffs);
            caffViewModelWithCount.Values = caffViewModelWithCount.Values.Skip((request.Dto.PageCount - 1) * request.Dto.PageSize).Take(request.Dto.PageSize);
            return Task.FromResult(caffViewModelWithCount);
        }

        public async Task<byte[]> Handle(GetCaffDownloadQuery request, CancellationToken cancellationToken)
        {
            var caffEntity = _unitOfWork.CaffRepository.Get(
                filter: x => x.Id == request.CaffId,
                transform: x => x.AsNoTracking(),
                includeProperties: nameof(Caff.BoughtBy)
                ).FirstOrDefault();
            if (caffEntity == null)
            {
                throw new EntityNotFoundException("Requested caff file not found");
            }

            _validator = new OwnershipValidator(caffEntity, request.User);
            if (!_validator.Validate())
            {
                throw new ValidationErrorException("Validation error occured");
            }

            return await File.ReadAllBytesAsync(caffEntity.PhysicalPath, cancellationToken);
        }
    }
}
