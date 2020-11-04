using System.Linq;
using AutoShop.Data.Interfaces;
using AutoShop.Models;
using AutoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.Controllers
{
    public class AutoShopCartController : Controller
    {
        private readonly IAllCars carRepository;
        private readonly AutoShopCart autoShopCart;

        public AutoShopCartController(IAllCars carRepository, AutoShopCart autoShopCart)
        {
            this.carRepository = carRepository;
            this.autoShopCart = autoShopCart;
        }

        public ViewResult Index()
        {
            var items = autoShopCart.GetAutoShopItems();
            autoShopCart.ListAutoShopItems = items;
            var obj = new AutoShopCartViewModel
            {
                AutoShopCart = autoShopCart
            };

            ViewBag.Title = "Корзина";

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = carRepository.Cars.FirstOrDefault(i => i.Id == id);
            
            if(item != null)
            {
                autoShopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
