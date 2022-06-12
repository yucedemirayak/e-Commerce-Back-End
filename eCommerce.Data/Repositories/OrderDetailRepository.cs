using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class OrderDetailRepository : RepositoryProvider<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
