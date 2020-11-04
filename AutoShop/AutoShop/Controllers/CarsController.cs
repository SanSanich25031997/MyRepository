using Microsoft.AspNetCore.Mvc;
using AutoShop.Data.Interfaces;
using AutoShop.ViewModels;
using AutoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars allCars;
        private readonly ICarsCategory allCategories;

        public CarsController(IAllCars allCars, ICarsCategory allCategories)
        {
            this.allCars = allCars;
            this.allCategories = allCategories;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            IEnumerable<Car> cars = null;
            string carCategory = "";

            if(string.IsNullOrEmpty(category))
            {
                cars = allCars.Cars.OrderBy(i => i.Id);
            }
            else
            {
                if(string.Equals("Electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(i => i.Category.CategoryName.Equals("Электромобили")).OrderBy(i => i.Id);
                    carCategory = "Электромобили";
                }
                else if (string.Equals("Fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(i => i.Category.CategoryName.Equals("Топливные автомобили")).OrderBy(i => i.Id);
                    carCategory = "Топливные автомобили";
                }       
            }

            var carObject = new CarsListViewModel
            {
                AllCars = cars,
                CarCategory = carCategory
            };

            ViewBag.Title = "Автомобили";
            if(carCategory != "")
            {
                ViewBag.Title = carCategory;
            }

            return View(carObject);
        }
    }
}
