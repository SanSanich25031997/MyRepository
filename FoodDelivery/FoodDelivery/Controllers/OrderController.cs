using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Models;
using FoodDelivery.Data.Interfaces;

namespace FoodDelivery.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly FoodDeliveryCart foodDeliveryCart;

        public OrderController(IAllOrders allOrders, FoodDeliveryCart foodDeliveryCart)
        {
            this.allOrders = allOrders;
            this.foodDeliveryCart = foodDeliveryCart;
        }

        public IActionResult Checkout()
        {
            ViewBag.Title = "Заказ";

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            foodDeliveryCart.ListFoodDeliveryItems = foodDeliveryCart.GetFoodDeliveryItems();

            if(foodDeliveryCart.ListFoodDeliveryItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина не должна быть пустой!");
            }

            if(ModelState.IsValid)
            {
                allOrders.CreateOrder(order);

                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Title = "Заказ";
            ViewBag.Message = "Заказ успешно обработан!";

            return View();
        }
    }
}
