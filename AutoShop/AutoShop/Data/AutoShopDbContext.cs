using Microsoft.EntityFrameworkCore;
using AutoShop.Models;

namespace AutoShop.Data
{
    public class AutoShopDbContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<AutoShopCartItem> AutoShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        public AutoShopDbContext(DbContextOptions<AutoShopDbContext> options) : base(options) { }
    }
}
