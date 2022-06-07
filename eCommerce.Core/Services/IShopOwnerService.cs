using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IShopOwnerService : IService<ShopOwner>
    {
        Task<ShopOwner> CreateNew(ShopOwner entity);
        Task<ShopOwner> GetByEmail(string email);
        Task<IEnumerable<ShopOwner>> GetAll();
    }
}
