using eCommerce.Core.Models;
using eCommerce.Core.Repositories;
using System.Collections.Generic;

namespace eCommerce.Data.Repositories
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
