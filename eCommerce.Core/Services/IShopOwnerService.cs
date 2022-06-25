using eCommerce.Core.Models;

namespace eCommerce.Core.Services
{
    public interface IShopOwnerService : IBaseService<ShopOwner>
    {
        Task<ShopOwner> ReceiveByEmail(string email);
    }
}
