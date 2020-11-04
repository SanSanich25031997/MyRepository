using System.Collections.Generic;
using System.Linq;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
    public class DbObjects
    {
        private static Dictionary<string, Company> company;

        public static Dictionary<string, Company> Companies
        {
            get
            {
                if(company == null)
                {
                    var list = new Company[]
                    {
                        new Company {Name = "Додо Пицца", Description = "Российская сеть ресторанов быстрого питания, специализирующаяся на пицце."},
                        new Company {Name = "Сушивок", Description = "Первая сеть магазинов японской и китайской кухни в России."},
                        new Company {Name = "Subway", Description = "Крупнейшая по количеству точек предприятий общественного питания сеть в мире."}
                    };

                    company = new Dictionary<string, Company>();

                    foreach(Company element in list)
                    {
                        company.Add(element.Name, element);
                    }
                }

                return company;
            }
        }

        public static void Initial(FoodDeliveryDbContext context)
        {
            if(!context.Company.Any())
            {
                context.Company.AddRange(Companies.Select(c => c.Value));
            }

            if(!context.Product.Any())
            {
                context.AddRange(
                    new Product
                    {
                        Name = "Пицца «Гавайская»",
                        Description = "Пицца «Гавайская». Тонкое тесто, сочная ароматная начинка — это очень вкусно!",
                        Image = "/images/Pizza1.jpg",
                        Price = 295,
                        IsFavorite = true,
                        IsAvailable = true,
                        Company = Companies["Додо Пицца"]
                    },
                    new Product
                    {
                        Name = "Суши «Жаркий сезон»",
                        Description = "Запеч. ролл Аяши, запеч. ролл Румяный, запеч. ролл Сырный, запеч. ролл Лососик Хот с терияки , " +
                        "запеч. ролл Шиитаке, запеч. ролл Крабик Хот 1056 г",
                        Image = "/images/Sushi1.jpg",
                        Price = 985,
                        IsFavorite = true,
                        IsAvailable = true,
                        Company = Companies["Сушивок"]
                    },
                    new Product
                    {
                        Name = "Subway «Куриная грудка»",
                        Description = "Нежное филе курицы в сочетании со свежими овощами по Вашему выбору на свежевыпеченном хлебе.",
                        Image = "/images/Subway1.jpg",
                        Price = 150,
                        IsFavorite = true,
                        IsAvailable = true,
                        Company = Companies["Subway"]
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
