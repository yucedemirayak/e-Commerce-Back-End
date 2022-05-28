using eCommerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
    }
}
