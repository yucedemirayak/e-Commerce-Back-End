using eCommerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartsDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FavouriteList> FavoriteLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ShopOwner> ShopOwners { get; set; }
        public DbSet<ShopOwnerAdress> ShopOwnerAdresses { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdress> UserAdresses { get; set; }

    }
}
