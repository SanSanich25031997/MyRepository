using AutoShop.Data.Interfaces;
using AutoShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly AutoShopCart autoShopCart;

        public OrderController(IAllOrders allOrders, AutoShopCart autoShopCart)
        {
            this.allOrders = allOrders;
            this.autoShopCart = autoShopCart;
        }

        public IActionResult Checkout()
        {
            ViewBag.Title = "Заказ";

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            autoShopCart.ListAutoShopItems = autoShopCart.GetAutoShopItems();

            if(autoShopCart.ListAutoShopItems.Count == 0)
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
