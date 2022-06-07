using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class ShopOwnerRepository : Repository<ShopOwner>, IShopOwnerRepository
    {
        public ShopOwnerRepository(eCommerceDbContext context) : base(context) { }
    }
}
