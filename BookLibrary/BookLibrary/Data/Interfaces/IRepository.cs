using System;
using System.Collections.Generic;

namespace BookLibrary.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T GetById(int id);
        void Create(T entity);
        void Update(T enitity);
        void Delete(T entity);
        int Count(Func<T, bool> predicate);
    }
}
