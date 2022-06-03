

using eCommerce.Core.Models;
using eCommerce.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data.Repositories
{
    public class AdminRepository : Repository<Admin>, IAdminRepository
    {
        public AdminRepository(eCommerceDbContext context) : base(context) { }


    }
}
