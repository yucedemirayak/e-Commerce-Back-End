using eCommerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<ShopOwner> ShopOwner { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCatoregory> SubCategories { get; set; }
        public DbSet<Adress> Adresses { get; set; }

    }
}
