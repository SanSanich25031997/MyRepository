using System.Collections.Generic;
using System.Linq;
using AutoShop.Models;

namespace AutoShop.Data
{
    public class DbObjects
    {
        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Электромобили", Description = "Современный вид транспорта"},
                        new Category { CategoryName = "Топливные автомобили", Description = "Автомобиль с двигателем внутреннего сгорания" }
                    };

                    category = new Dictionary<string, Category>();

                    foreach(Category element in list)
                    {
                        category.Add(element.CategoryName, element);
                    }
                }

                return category;
            }
        }

        public static void Initial(AutoShopDbContext context)
        {
            if(!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(c => c.Value));
            }

            if(!context.Car.Any())
            {
                context.AddRange(
                    new Car
                    {
                        Name = "Tesla",
                        ShortDescription = "Очень популярные электромобили",
                        Image = "/images/Tesla.jpg",
                        Price = 450000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Электромобили"],
                    },
                    new Car
                    {
                        Name = "BMW X5",
                        ShortDescription = "Один из самых популярных автомобилей мира.",
                        Image = "/images/BMW.jpg",
                        Price = 5150000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Топливные автомобили"],
                    },
                    new Car
                    {
                        Name = "Mercedes-Benz",
                        ShortDescription = "Одна из самых популярных машин мира.",
                        Image = "/images/Mercedes.jpg",
                        Price = 2230000,
                        IsFavorite = true,
                        Available = true,
                        Category = Categories["Топливные автомобили"],
                    },
                    new Car
                    {
                        Name = "LADA Granta",
                        ShortDescription = "Очень популярный автомобиль в России.",
                        Image = "/images/LADA.jpg",
                        Price = 483900,
                        IsFavorite = false,
                        Available = true,
                        Category = Categories["Топливные автомобили"],
                    },
                    new Car
                    {
                        Name = "Toyota Prius",
                        ShortDescription = "Довольно известный автомобиль",
                        Image = "/images/Toyota.jpg",
                        Price = 2322000,
                        IsFavorite = false,
                        Available = true,
                        Category = Categories["Электромобили"],
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
