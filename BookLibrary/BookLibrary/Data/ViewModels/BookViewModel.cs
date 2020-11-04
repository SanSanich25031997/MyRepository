using System.Collections.Generic;
using BookLibrary.Models;

namespace BookLibrary.Data.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
