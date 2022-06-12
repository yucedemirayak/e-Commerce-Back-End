using eCommerce.Core.Services;

namespace eCommerce.Core
{
    public interface IServiceProvider
    {
        IAdminService AdminServices { get; }
        ICartDetailService CartDetailServices { get; }
        ICartService CartServices { get; }
        ICategoryService CategoryServices { get; }
        IFavouriteListService FavoriteListServices { get; }
        IOrderDetailService OrderDetailServices { get; }
        IOrderService OrderServices { get; }
        IProductImageService ProductImageServices { get; }
        IProductService ProductServices { get; }
        IShopOwnerAdressService ShopOwnerAdressServices { get; }
        IShopOwnerService ShopOwnerServices { get; }
        ISubCategoryService SubCategoryServices { get; }
        IUserAdressService UserAdressServices { get; }
        IUserService UserServices { get; }
    }
}
