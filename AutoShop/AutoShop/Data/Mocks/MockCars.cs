using System.Collections.Generic;
using System.Linq;
using AutoShop.Models;
using AutoShop.Data.Interfaces;

namespace AutoShop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory CategoryCars = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name = "Tesla Model s",
                        ShortDescription = "Очень популярные электромобили",
                        Image = "/images/Tesla.jpg",
                        Price = 3900000,
                        IsFavorite = true,
                        Available = true,
                        Category = CategoryCars.AllCategories.First(),
                    },
                    new Car
                    {
                        Name = "BMW X5",
                        ShortDescription = "Один из самых популярных автомобилей мира.",
                        Image = "/images/BMW.jpg",
                        Price = 5150000,
                        IsFavorite = true,
                        Available = true,
                        Category = CategoryCars.AllCategories.Last(),
                    },
                    new Car
                    {
                        Name = "Mercedes-Benz",
                        ShortDescription = "Одна из самых популярных машин мира.",
                        Image = "/images/Mercedes.jpg",
                        Price = 2230000,
                        IsFavorite = true,
                        Available = true,
                        Category = CategoryCars.AllCategories.Last(),
                    },
                    new Car
                    {
                        Name = "LADA Granta",
                        ShortDescription = "Очень популярный автомобиль в России.",
                        Image = "/images/LADA.jpg",
                        Price = 483900,
                        IsFavorite = false,
                        Available = true,
                        Category = CategoryCars.AllCategories.Last(),
                    },
                    new Car
                    {
                        Name = "Toyota Prius",
                        ShortDescription = "Довольно известный автомобиль",
                        Image = "/images/Toyota.jpg",
                        Price = 2322000,
                        IsFavorite = false,
                        Available = true,
                        Category = CategoryCars.AllCategories.First(),
                    }
                };
            }
        }

        public IEnumerable<Car> GetFavoriteCars { get; set; }

        public Car GetObjectCar(int carId)
        {
            return null;
        }
    }
}
