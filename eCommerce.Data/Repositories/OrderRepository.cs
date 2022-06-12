using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class OrderRepository : RepositoryProvider<Order>, IOrderRepository
    {
        public OrderRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
