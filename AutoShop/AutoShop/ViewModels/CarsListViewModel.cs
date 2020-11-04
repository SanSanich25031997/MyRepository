using System.Collections.Generic;
using AutoShop.Models;

namespace AutoShop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string CarCategory { get; set; }
    }
}
