using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class ShopOwnerRepository : RepositoryProvider<ShopOwner>, IShopOwnerRepository
    {
        public ShopOwnerRepository(eCommerceDbContext context) : base(context) { }
    }
}
