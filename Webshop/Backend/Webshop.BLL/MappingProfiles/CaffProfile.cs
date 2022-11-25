using AutoMapper;
using Webshop.BLL.Infrastructure.DataTransferObjects;
using Webshop.BLL.Infrastructure.ViewModels;
using Webshop.BLL.ValueResolvers;
using Webshop.DAL.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.BLL.MappingProfiles
{
    public class CaffProfile : Profile
    {
        public CaffProfile() 
        {
            CreateMap<UploadCaffDTO, Caff>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(x => 0))
                .ForMember(dest => dest.Uploader, opt => opt.Ignore()) //ezt majd httpcontextből
                .ForMember(dest => dest.Ciffs, opt => opt.Ignore())
                .ForMember(dest => dest.Creator, opt => opt.Ignore())
                .ForMember(dest => dest.BoughtBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreationDate, opt => opt.Ignore());

            CreateMap<Caff, CaffListViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Uploader, opt => opt.MapFrom(src => src.Uploader))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.CoverUrl, opt => opt.ConvertUsing<AlbumDisplayUrlConverter, Caff>(src => src));

            CreateMap<Caff, CaffDetailsViewModel>();

            CreateMap<Ciff, CiffViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DisplayUrl, opt => opt.ConvertUsing<PictureDisplayUrlConverter, Ciff>(src => src));
        }
    }
}
