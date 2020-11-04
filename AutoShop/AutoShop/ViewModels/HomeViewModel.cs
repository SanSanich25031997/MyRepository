using System.Collections.Generic;
using AutoShop.Models;

namespace AutoShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> FavoriteCars { get; set; }
    }
}
