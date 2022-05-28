using AutoMapper;
using eCommerce.Api.Resources;
using eCommerce.Core.Models;

namespace eCommerce.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, AdminResource>();
            CreateMap<Admin, SaveAdminResource>();

            CreateMap<AdminResource, Admin>();
            CreateMap<SaveAdminResource, Admin>();
        }
    }
}
