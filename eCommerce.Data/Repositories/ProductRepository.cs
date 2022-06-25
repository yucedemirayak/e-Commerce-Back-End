using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
