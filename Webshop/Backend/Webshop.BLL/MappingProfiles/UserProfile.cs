using AutoMapper;
using Webshop.BLL.Infrastructure.DataTransferObjects;
using Webshop.BLL.Infrastructure.ViewModels;
using Webshop.DAL.Domain;

namespace Webshop.BLL.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, EditUserDto>().ReverseMap();
            CreateMap<ApplicationUser, EditUserRoleDto>().ReverseMap();

            CreateMap<RegisterUserDto, ApplicationUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(a => a.UserName.Trim()))
                .ForMember(u => u.FirstName, opt => opt.MapFrom(a => a.FirstName.Trim()))
                .ForMember(u => u.LastName, opt => opt.MapFrom(a => a.LastName.Trim()))
                .ForMember(u => u.Email, opt => opt.MapFrom(a => a.Email.Trim()))
                .ReverseMap();

            CreateMap<ApplicationUser, ProfileViewModel>()
                .ForMember(u => u.Name, opt => opt.MapFrom(a => a.GetFullName()))
                .ReverseMap();
            CreateMap<ApplicationUser, ProfileWithNameViewModel>()
                .ReverseMap();
            CreateMap<ApplicationUser, UserNameViewModel>()
                .ReverseMap();

            CreateMap<RegisterUserDto, ApplicationUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(a => a.UserName.Trim()))
                .ForMember(u => u.FirstName, opt => opt.MapFrom(a => a.FirstName.Trim()))
                .ForMember(u => u.LastName, opt => opt.MapFrom(a => a.LastName.Trim()))
                .ForMember(u => u.Email, opt => opt.MapFrom(a => a.Email.Trim()))
                .ReverseMap();
        }
    }
}
