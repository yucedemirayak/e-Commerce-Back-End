using eCommerce.Core.Models;
using eCommerce.Core.Repositories;

namespace eCommerce.Data.Repositories
{
    public class AdminRepository : RepositoryProvider<Admin>, IAdminRepository
    {
        public AdminRepository(eCommerceDbContext context) : base(context) 
        {
        }
    }
}
