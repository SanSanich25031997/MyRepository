using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.Models;
using FoodDelivery.ViewModels;
using FoodDelivery.Data.Interfaces;

namespace FoodDelivery.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IAllProducts allProducts;
        private readonly IAllCompanies allCompanies;

        public ProductsController(IAllProducts allProducts, IAllCompanies allCompanies)
        {
            this.allProducts = allProducts;
            this.allCompanies = allCompanies;
        }

        [Route("Products/List")]
        [Route("Products/List/{company}")]
        public ViewResult List(string company)
        {
            IEnumerable<Product> products = null;
            string productCompany = "";

            if(string.IsNullOrEmpty(company))
            {
                products = allProducts.AllProducts.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("DodoPizza", company, StringComparison.OrdinalIgnoreCase))
                {
                    products = allProducts.AllProducts.Where(i => i.Company.Name.Equals("Додо Пицца")).OrderBy(i => i.Id);
                    productCompany = "Додо Пицца";
                }
                else if (string.Equals("Sushiwok", company, StringComparison.OrdinalIgnoreCase))
                {
                    products = allProducts.AllProducts.Where(i => i.Company.Name.Equals("Сушивок")).OrderBy(i => i.Id);
                    productCompany = "Сушивок";
                }
                else if (string.Equals("Subway", company, StringComparison.OrdinalIgnoreCase))
                {
                    products = allProducts.AllProducts.Where(i => i.Company.Name.Equals("Subway")).OrderBy(i => i.Id);
                    productCompany = "Subway";
                }
            }

            var productObject = new ProductsListViewModel
            {
                AllProducts = products,
                Company = productCompany
            };

            ViewBag.Title = "Продукты";

            if(productCompany != "")
            {
                ViewBag.Title = productCompany;
            }

            return View(productObject);
        }
    }
}
