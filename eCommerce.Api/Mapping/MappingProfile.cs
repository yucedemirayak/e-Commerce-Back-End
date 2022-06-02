using AutoMapper;
using eCommerce.Api.DTOs.Admin;
using eCommerce.Api.DTOs.User;
using eCommerce.Core.Models;

namespace eCommerce.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Admin, AdminDTO>();
            CreateMap<Admin, SaveAdminDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<User, SaveUserDTO>();

            // Resource to Domain
            CreateMap<AdminDTO, Admin>();
            CreateMap<SaveAdminDTO, Admin>();
            CreateMap<UserDTO, User>();
            CreateMap<SaveUserDTO, User>();
        }
    }
}
