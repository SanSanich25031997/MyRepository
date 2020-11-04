using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FoodDelivery.Data;

namespace FoodDelivery.Models
{
    public class FoodDeliveryCart
    {
        public string FoodDeliveryCartId { get; set; }
        public List<FoodDeliveryCartItem> ListFoodDeliveryItems { get; set; }

        private readonly FoodDeliveryDbContext foodDeliveryDbContext;
    
        public FoodDeliveryCart(FoodDeliveryDbContext foodDeliveryDbContext)
        {
            this.foodDeliveryDbContext = foodDeliveryDbContext;
        }

        public static FoodDeliveryCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<FoodDeliveryDbContext>();
            string foodDeliveryCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", foodDeliveryCartId);

            return new FoodDeliveryCart(context) { FoodDeliveryCartId = foodDeliveryCartId };
        }

        public void AddToCart(Product product)
        {
            foodDeliveryDbContext.FoodDeliveryCartItem.Add(new FoodDeliveryCartItem
            {
                FoodDeliveryCartId = FoodDeliveryCartId,
                Product = product,
                Price = product.Price
            });

            foodDeliveryDbContext.SaveChanges();
        }

        public List<FoodDeliveryCartItem> GetFoodDeliveryItems()
        {
            return foodDeliveryDbContext.FoodDeliveryCartItem.Where(i => i.FoodDeliveryCartId == FoodDeliveryCartId).Include(i => i.Product).ToList();
        }
    }
}
