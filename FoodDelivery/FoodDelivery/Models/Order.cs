using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodDelivery.Models
{
    public class Order
    {
        public int Id { get; set; } //Идентификационный номер
        public string Name { get; set; } //Имя заказчика
        public string LastName { get; set; } //Фамилия заказчика
        public string Address { get; set; } //Адрес
        public string Phone { get; set; } //Телефон
        public string Email { get; set; } //E-mail
        public DateTime OrderDate { get; set; } //Дата заказа
        public List<OrderDetails> OrderDetails { get; set; } //Детали заказа

    }
}
