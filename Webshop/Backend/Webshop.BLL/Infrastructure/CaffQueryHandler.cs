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
        private const int _albumPictureCount = 9;

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
                includeProperties: string.Join(',', nameof(Caff.Uploader), nameof(Caff.Ciffs), nameof(Caff.Comments)))
                .FirstOrDefault();
            if (caffEntity == null)
            {
                throw new EntityNotFoundException("Requested caff not found");
            }

            var albumViewModel = _mapper.Map<CaffDetailsViewModel>(caffEntity);
            return Task.FromResult(albumViewModel);
        }

        public Task<EnumerableWithTotalViewModel<CaffListViewModel>> Handle(GetCaffListQuery request, CancellationToken cancellationToken)
        {
            var albumEntities = _unitOfWork.CaffRepository.Get(
                filter: null,
                transform: x => x.AsNoTracking()
                ).ToList();

            var albumsViewModelWithCount = _mapper.Map<EnumerableWithTotalViewModel<CaffListViewModel>>(albumEntities);
            albumsViewModelWithCount.Values = albumsViewModelWithCount.Values.Skip((request.Dto.PageCount - 1) * request.Dto.PageSize).Take(request.Dto.PageSize);
            return Task.FromResult(albumsViewModelWithCount);
        }

        public Task<EnumerableWithTotalViewModel<CaffListViewModel>> Handle(GetBoughtCaffsQuery request, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(request.User.GetUserIdFromJwt());
            var albumEntities = _unitOfWork.UserRepository.Get(
                filter: x => x.Id == userId,
                transform: x => x.AsNoTracking(),
                includeProperties: string.Join(',', $"{nameof(ApplicationUser.BoughtCaffs)}.{nameof(Caff)}", $"{nameof(ApplicationUser.BoughtCaffs)}.{nameof(Caff.Uploader)}")
                ).First();

            var albumsViewModelWithCount = _mapper.Map<EnumerableWithTotalViewModel<CaffListViewModel>>(albumEntities.BoughtCaffs);
            albumsViewModelWithCount.Values = albumsViewModelWithCount.Values.Skip((request.Dto.PageCount - 1) * request.Dto.PageSize).Take(request.Dto.PageSize);
            return Task.FromResult(albumsViewModelWithCount);
        }

        public Task<byte[]> Handle(GetCaffDownloadQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
