using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class ShopOwnerAdressRepository : RepositoryProvider<ShopOwnerAdress>, IShopOwnerAdressRepository
    {
        public ShopOwnerAdressRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
