using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Data.Interfaces;
using FoodDelivery.ViewModels;

namespace FoodDelivery.Controllers
{
    public class HomeController : Controller
    {
        private IAllProducts productRepository;

        public HomeController(IAllProducts productRepository)
        {
            this.productRepository = productRepository;
        }

        public ViewResult Index()
        {
            var favoriteProducts = new HomeViewModel
            {
                FavoriteProducts = productRepository.GetFavoriteProducts
            };

            ViewBag.Title = "Главная страница";

            return View(favoriteProducts);
        }
    }
}
