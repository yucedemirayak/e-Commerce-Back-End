using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class ProductImageRepository : RepositoryProvider<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
