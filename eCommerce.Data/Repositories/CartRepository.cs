using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
