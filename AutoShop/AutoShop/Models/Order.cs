using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AutoShop.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name="Введите имя")]
        [MinLength(1)]
        [Required(ErrorMessage = "Длина имени должна быть не менее 1 символа")]
        public string Name { get; set; }
        [Display(Name = "Введите фамилию")]
        [MinLength(1)]
        [Required(ErrorMessage = "Длина фамилии должна быть не менее 1 символа")]
        public string LastName { get; set; }
        [Display(Name = "Ваш адрес")]
        [MinLength(10)]
        [Required(ErrorMessage = "Длина адреса должна быть не менее 10 символов")]
        public string Address { get; set; }
        [Display(Name = "Номер телефона")]
        [MinLength(5)]
        [Required(ErrorMessage = "Длина номера должна быть телефона не  менее 5 символов")]
        public string Phone { get; set; }
        [Display(Name = "Вам E-mail")]
        [DataType(DataType.EmailAddress)]
        [MinLength(5)]
        [Required(ErrorMessage = "Длина е-mail должна быть не менее 5 символов")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
