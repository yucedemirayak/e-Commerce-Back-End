using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class CategoryRepository : RepositoryProvider<Category>, ICategoryRepository
    {
        public CategoryRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
