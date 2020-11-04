using Microsoft.AspNetCore.Mvc;
using BookLibrary.Data.Interfaces;
using BookLibrary.Data.ViewModels;

namespace BookLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly ICustomerRepository customerRepository;

        public HomeController(IBookRepository bookRepository,
            IAuthorRepository authorRepository, ICustomerRepository customerRepository)
        {
            this.bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                AuthorCount = authorRepository.Count(x => true),
                CustomerCount = customerRepository.Count(x => true),
                BookCount = bookRepository.Count(x => true),
                LendBookCount = bookRepository.Count(x => x.Borrower != null)
            };

            return View(homeViewModel);
        }
    }
}
