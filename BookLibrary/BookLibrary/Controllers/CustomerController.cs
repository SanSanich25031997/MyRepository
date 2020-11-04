using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookLibrary.Models;
using BookLibrary.Data.Interfaces;
using BookLibrary.Data.ViewModels;

namespace BookLibrary.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IBookRepository bookRepository;

        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            this.customerRepository = customerRepository;
            this.bookRepository = bookRepository;
        }

        [Route("Customer")]
        public IActionResult List()
        {
            var customerViewModel = new List<CustomerViewModel>();
            var customers = customerRepository.GetAll();

            if(customers.Count() == 0)
            {
                return View("Empty");
            }

            foreach(var customer in customers)
            {
                customerViewModel.Add(new CustomerViewModel()
                {
                    Customer = customer,
                    BookCount = bookRepository.Count(x => x.BorrowerId == customer.CustomerId)
                }) ;
            }

            return View(customerViewModel);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return View(customer);
            }

            customerRepository.Create(customer);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return View(customer);
            }

            customerRepository.Update(customer);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var customer = customerRepository.GetById(id);

            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = customerRepository.GetById(id);

            customerRepository.Delete(customer);

            return RedirectToAction("List");
        }
    }
}
