using System.Collections.Generic;
using BookLibrary.Models;

namespace BookLibrary.Data.ViewModels
{
    public class LendViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
