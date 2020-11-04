using System.Collections.Generic;
using System.Linq;
using FoodDelivery.Data.Interfaces;
using FoodDelivery.Models;

namespace FoodDelivery.Data.Mocks
{
    public class MockProducts : IAllProducts
    {
        private readonly IAllCompanies Companies = new MockCompanies();

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return new List<Product>
                {
                    new Product
                    {
                        Name = "Пицца «Гавайская»",
                        Description = "Пицца «Гавайская». Тонкое тесто, сочная ароматная начинка — это очень вкусно!",
                        Image = "/images/Pizza1.jpg",
                        Price = 295,
                        IsFavorite = true,
                        IsAvailable = true,
                        Company = Companies.AllCompanies.First()
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
                        Company = Companies.AllCompanies.Skip(1).First()
                    },
                    new Product
                    {
                        Name = "Subway «Куриная грудка»",
                        Description = "Нежное филе курицы в сочетании со свежими овощами по Вашему выбору на свежевыпеченном хлебе.",
                        Image = "/images/Subway1.jpg",
                        Price = 150,
                        IsFavorite = true,
                        IsAvailable = true,
                        Company = Companies.AllCompanies.Last()
                    }
                };
            }
        }

        public IEnumerable<Product> GetFavoriteProducts { get; set; }

        public Product GetObjectProduct(int productId)
        {
            return null;
        }
    }
}
