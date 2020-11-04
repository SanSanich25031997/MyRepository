using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoShop.Data.Interfaces;
using AutoShop.Models;

namespace AutoShop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AutoShopDbContext autoShopDbContext;

        public CarRepository(AutoShopDbContext autoShopDbContext)
        {
            this.autoShopDbContext = autoShopDbContext;
        }

        public IEnumerable<Car> Cars => autoShopDbContext.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavoriteCars => autoShopDbContext.Car.Where(p => p.IsFavorite).Include(c => c.Category);

        public Car GetObjectCar(int carId) => autoShopDbContext.Car.FirstOrDefault(p => p.Id == carId);
    }
}
