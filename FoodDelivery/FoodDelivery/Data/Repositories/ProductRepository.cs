using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Models;
using FoodDelivery.Data.Interfaces;

namespace FoodDelivery.Data.Repositories
{
    public class ProductRepository : IAllProducts
    {
        private readonly FoodDeliveryDbContext foodDeliveryDbContext;

        public ProductRepository(FoodDeliveryDbContext foodDeliveryDbContext)
        {
            this.foodDeliveryDbContext = foodDeliveryDbContext;
        }

        public IEnumerable<Product> AllProducts => foodDeliveryDbContext.Product.Include(p => p.Company);

        public IEnumerable<Product> GetFavoriteProducts => foodDeliveryDbContext.Product.Where(p => p.IsFavorite).Include(p => p.Company);

        public Product GetObjectProduct(int productId) => foodDeliveryDbContext.Product.FirstOrDefault(p => p.Id == productId);
    }
}
