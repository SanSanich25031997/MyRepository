using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoShop.Data;

namespace AutoShop.Models
{
    public class AutoShopCart
    {
        public string AutoShopCartId { get; set; }
        public List<AutoShopCartItem> ListAutoShopItems { get; set; }
        
        private readonly AutoShopDbContext autoShopDbContext;

        public AutoShopCart(AutoShopDbContext autoShopDbContext)
        {
            this.autoShopDbContext = autoShopDbContext;
        }

        public static AutoShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AutoShopDbContext>();
            string autoShopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", autoShopCartId);

            return new AutoShopCart(context) { AutoShopCartId = autoShopCartId };
        }

        public void AddToCart(Car car)
        {
            autoShopDbContext.AutoShopCartItem.Add(new AutoShopCartItem
            {
                AutoShopCartId = AutoShopCartId, 
                Car = car,
                Price = car.Price
            });

            autoShopDbContext.SaveChanges();
        }

        public List<AutoShopCartItem> GetAutoShopItems()
        {
            return autoShopDbContext.AutoShopCartItem.Where(c => c.AutoShopCartId == AutoShopCartId).Include(s => s.Car).ToList();
        }
    }
}
