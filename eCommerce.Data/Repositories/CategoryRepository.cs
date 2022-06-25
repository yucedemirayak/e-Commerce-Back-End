using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
