using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookLibrary.Models;
using BookLibrary.Data.Interfaces;
using BookLibrary.Data.ViewModels;

namespace BookLibrary.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        [Route("Author")]
        public IActionResult List()
        {
            var authors = authorRepository.GetAllWithBooks();

            if(authors.Count() == 0)
            {
                return View("Empty");
            }

            return View(authors);
        }

        [HttpPost]
        public IActionResult Create(AuthorViewModel authorViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(authorViewModel);
            }

            authorRepository.Create(authorViewModel.Author);

            if(!String.IsNullOrEmpty(authorViewModel.Referer))
            {
                return Redirect(authorViewModel.Referer);
            }

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            var authorViewModel = new AuthorViewModel
            { Referer = Request.Headers["Referer"].ToString() };

            return View(authorViewModel);
        }

        [HttpPost]
        public IActionResult Update(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            authorRepository.Update(author);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var author = authorRepository.GetById(id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        public IActionResult Delete(int id)
        {
            var author = authorRepository.GetById(id);

            authorRepository.Delete(author);

            return RedirectToAction("List");
        }
    }
}
