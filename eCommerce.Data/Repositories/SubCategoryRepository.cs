using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class SubCategoryRepository : RepositoryProvider<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
