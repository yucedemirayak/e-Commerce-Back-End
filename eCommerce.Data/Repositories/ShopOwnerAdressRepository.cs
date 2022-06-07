using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class ShopOwnerAdressRepository : Repository<ShopOwnerAdress>, IShopOwnerAdressRepository
    {
        public ShopOwnerAdressRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
