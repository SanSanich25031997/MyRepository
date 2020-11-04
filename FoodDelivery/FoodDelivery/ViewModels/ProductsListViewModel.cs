using System.Collections.Generic;
using FoodDelivery.Models;

namespace FoodDelivery.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
        public string Company { get; set; }
    }
}
