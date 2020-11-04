using Microsoft.EntityFrameworkCore;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
    public class FoodDeliveryDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<FoodDeliveryCartItem> FoodDeliveryCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public FoodDeliveryDbContext(DbContextOptions<FoodDeliveryDbContext> options) : base(options) { }
    }
}
