using System.Collections.Generic;
using FoodDelivery.Models;

namespace FoodDelivery.Data.Interfaces
{
    public interface IAllProducts
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> GetFavoriteProducts { get; }
        Product GetObjectProduct(int productId);
    }
}
