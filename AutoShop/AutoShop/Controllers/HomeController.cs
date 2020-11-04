using AutoShop.Data.Interfaces;
using AutoShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.Controllers
{
    public class HomeController : Controller
    {
        private IAllCars carRepository;

        public HomeController(IAllCars carRepository)
        {
            this.carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavoriteCars = carRepository.GetFavoriteCars
            };

            ViewBag.Title = "Главная страница";

            return View(homeCars);
        }
    }
}
