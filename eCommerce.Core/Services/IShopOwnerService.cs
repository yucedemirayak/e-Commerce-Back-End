using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IShopOwnerService : IBaseService<ShopOwner>
    {
        Task<ShopOwner> Create(ShopOwner entity);
        Task<ShopOwner> GetByEmail(string email);
        Task<IEnumerable<ShopOwner>> GetAll();
    }
}
