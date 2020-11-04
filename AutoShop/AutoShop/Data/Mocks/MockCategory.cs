using System.Collections.Generic;
using AutoShop.Data.Interfaces;
using AutoShop.Models;

namespace AutoShop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Электромобили", Description = "Современный вид транспорта"},
                    new Category { CategoryName = "Топливные автомобили", Description = "Автомобиль с двигателем внутреннего сгорания" }
                };
            }
        }
    }
}
