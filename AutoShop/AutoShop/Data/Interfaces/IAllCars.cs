using System.Collections.Generic;
using AutoShop.Models;

namespace AutoShop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFavoriteCars { get; }
        Car GetObjectCar(int carId);
    }
}