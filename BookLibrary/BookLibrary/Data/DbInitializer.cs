using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BookLibrary.Models;

namespace BookLibrary.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();

                var customer1 = new Customer { Name = "Александр", LastName = "Александров" };
                context.Customers.Add(customer1);

                var customer2 = new Customer { Name = "Алексей", LastName = "Алексеев" };
                context.Customers.Add(customer2);

                var customer3 = new Customer { Name = "Андрей", LastName = "Андреев" };
                context.Customers.Add(customer3);

                var author1 = new Author
                {
                    Name = "Александр",
                    LastName = "Пушкин",
                    Books = new List<Book>()
                    {
                        new Book {Title = "Капитанская дочка"},
                        new Book {Title = "Евгений Онегин"},
                        new Book {Title = "Пиковая дама"},
                        new Book {Title = "Руслан и Людмила"}
                    }
                };
                context.Authors.Add(author1);

                var author2 = new Author
                {
                    Name = "Федор",
                    LastName = "Достоевкий",
                    Books = new List<Book>()
                    {
                        new Book {Title = "Преступление и наказание"},
                        new Book {Title = "Братья Карамазовы"},
                        new Book {Title = "Идиот"},
                    }
                };
                context.Authors.Add(author2);

                var author3 = new Author
                {
                    Name = "Лев",
                    LastName = "Толстой",
                    Books = new List<Book>()
                    {
                        new Book {Title = "Война и мир"},
                        new Book {Title = "Анна Каренина"},
                        new Book {Title = "Воскресение"},
                    }
                };
                context.Authors.Add(author3);

                context.SaveChanges();
            }
        }
    }
}
