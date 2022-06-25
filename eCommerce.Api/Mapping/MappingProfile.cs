using AutoMapper;
using eCommerce.Api.DTOs.Admin;
using eCommerce.Api.DTOs.Category;
using eCommerce.Api.DTOs.ShopOwner;
using eCommerce.Api.DTOs.SubCategory;
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

            CreateMap<Category, CategoryDTO>();

            CreateMap<User, UserDTO>();
            CreateMap<User, SaveUserDTO>();

            CreateMap<ShopOwner, ShopOwnerDTO>();
            CreateMap<ShopOwner, SaveShopOwnerDTO>();

            CreateMap<SubCategory, SubCategoryDTO>();

            // Resource to Domain
            CreateMap<AdminDTO, Admin>();
            CreateMap<SaveAdminDTO, Admin>();

            CreateMap<CategoryDTO, Category>();

            CreateMap<UserDTO, User>();
            CreateMap<SaveUserDTO, User>();

            CreateMap<ShopOwnerDTO, ShopOwner>();
            CreateMap<SaveShopOwnerDTO, ShopOwner>();

            CreateMap<SubCategoryDTO, SubCategory>();
        }
    }
}
