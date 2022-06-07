using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class FavouriteListRepository : Repository<FavouriteList>, IFavouriteListRepository
    {
        public FavouriteListRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
