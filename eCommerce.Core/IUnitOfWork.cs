using eCommerce.Core.Repositories;

namespace eCommerce.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }
        ICartDetailRepository CartDetails { get; }
        ICartRepository Carts { get; }
        ICategoryRepository Categories { get; }
        IFavouriteListRepository FavoriteLists { get; }
        IOrderDetailRepository OrderDeatils { get; }
        IOrderRepository Orders { get; }
        IProductImageRepository ProductImages { get; }
        IProductRepository Products { get; }
        IShopOwnerAdressRepository ShopOwnerAdresses { get; }
        IShopOwnerRepository ShopOwners { get; }
        ISubCategoryRepository SubCategories { get; }
        IUserAdressRepository UserAdresses { get; }
        IUserRepository Users { get; }


        Task<int> CommitAsync();
    }
}
