using System.Collections.Generic;
using FoodDelivery.Models;
using FoodDelivery.Data.Interfaces;

namespace FoodDelivery.Data.Mocks
{
    public class MockCompanies : IAllCompanies
    {
        public IEnumerable<Company> AllCompanies
        {
            get
            {
                return new List<Company>
                {
                    new Company {Name = "Додо Пицца", Description = "Российская сеть ресторанов быстрого питания, специализирующаяся на пицце."},
                    new Company {Name = "Сушивок", Description = "Первая сеть магазинов японской и китайской кухни в России."},
                    new Company {Name = "Subway", Description = "Крупнейшая по количеству точек предприятий общественного питания сеть в мире."}
                };
            }
        }
    }
}
