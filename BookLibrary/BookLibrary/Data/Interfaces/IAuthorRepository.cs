using System.Collections.Generic;
using BookLibrary.Models;

namespace BookLibrary.Data.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAllWithBooks();
        Author GetWithBooks(int id);
    }
}
