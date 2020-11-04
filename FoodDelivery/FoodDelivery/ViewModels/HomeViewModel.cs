using System.Collections.Generic;
using FoodDelivery.Models;

namespace FoodDelivery.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> FavoriteProducts { get; set; }
    }
}
