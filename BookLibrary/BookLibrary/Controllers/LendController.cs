using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookLibrary.Data.Interfaces;
using BookLibrary.Data.ViewModels;

namespace BookLibrary.Controllers
{
    public class LendController : Controller
    {
        private readonly IBookRepository bookRepository;
        private readonly ICustomerRepository customerRepository;

        public LendController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            this.bookRepository = bookRepository;
            this.customerRepository = customerRepository;
        }

        [Route("Lend")]
        public IActionResult List()
        {
            var availableBooks = bookRepository.FindWithAuthor(x => x.BorrowerId == 0);

            if(availableBooks.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableBooks);
            }
        }

        public IActionResult LendBook(int bookId)
        {
            var lendViewModel = new LendViewModel()
            {
                Book = bookRepository.GetById(bookId),
                Customers = customerRepository.GetAll()
            };

            return View(lendViewModel);
        }

        [HttpPost]
        public IActionResult LendBook(LendViewModel lendViedModel)
        {
            var book = bookRepository.GetById(lendViedModel.Book.BookId);
            var customer = customerRepository.GetById(lendViedModel.Book.BorrowerId);
            book.Borrower = customer;

            bookRepository.Update(book);

            return RedirectToAction("List");
        }
    }
}
