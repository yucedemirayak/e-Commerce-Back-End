using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class ShopOwnerRepository : BaseRepository<ShopOwner>, IShopOwnerRepository
    {
        public ShopOwnerRepository(eCommerceDbContext context) : base(context) { }
    }
}
