using AutoMapper;
using eCommerce.Api.DTOs;
using eCommerce.Core.Models;

namespace eCommerce.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, AdminDTO>();
            CreateMap<Admin, SaveAdminDTO>();

            CreateMap<AdminDTO, Admin>();
            CreateMap<SaveAdminDTO, Admin>();
        }
    }
}
