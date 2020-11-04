using BookLibrary.Models;
using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryDbContext context) : base(context) { }
    }
}
