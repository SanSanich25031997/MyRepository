using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Models;
using FoodDelivery.ViewModels;
using FoodDelivery.Data.Interfaces;

namespace FoodDelivery.Controllers
{
    public class FoodDeliveryCartController : Controller
    {
        private readonly IAllProducts productRepository;
        private readonly FoodDeliveryCart foodDeliveryCart;

        public FoodDeliveryCartController(IAllProducts productRepository, FoodDeliveryCart foodDeliveryCart)
        {
            this.productRepository = productRepository;
            this.foodDeliveryCart = foodDeliveryCart;
        }

        public ViewResult Index()
        {
            var items = foodDeliveryCart.GetFoodDeliveryItems();
            foodDeliveryCart.ListFoodDeliveryItems = items;
            var obj = new FoodDeliveryCartViewModel
            {
                FoodDeliveryCart = foodDeliveryCart
            };

            ViewBag.Title = "Корзина";

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = productRepository.AllProducts.FirstOrDefault(i => i.Id == id);
        
            if(item != null)
            {
                foodDeliveryCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
