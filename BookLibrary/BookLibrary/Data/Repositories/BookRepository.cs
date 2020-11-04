using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models;
using BookLibrary.Data.Interfaces;

namespace BookLibrary.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibraryDbContext context) : base(context) { }

        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return context.Books.Include(a => a.Author).Where(predicate);
        }

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            return context.Books.Include(a => a.Author).
                Include(a => a.Borrower).Where(predicate);
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return context.Books.Include(a => a.Author);
        }
    }
}
