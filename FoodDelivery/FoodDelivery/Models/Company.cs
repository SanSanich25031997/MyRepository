using System.Collections.Generic;

namespace FoodDelivery.Models
{
    public class Company
    {
        public int Id { get; set; } //Идентификационный номер
        public string Name { get; set; } //Название компании
        public string Description { get; set; } //Описание
        public List<Product> AllProducts { get; set; } //Все продукты компании
    }
}
