using System;
using FoodDelivery.Models;
using FoodDelivery.Data.Interfaces;

namespace FoodDelivery.Data.Repositories
{
    public class OrderRepository : IAllOrders
    {
        private readonly FoodDeliveryDbContext foodDeliveryDbContext;
        private readonly FoodDeliveryCart foodDeliveryCart;

        public OrderRepository(FoodDeliveryDbContext foodDeliveryDbContext, FoodDeliveryCart foodDeliveryCart)
        {
            this.foodDeliveryDbContext = foodDeliveryDbContext;
            this.foodDeliveryCart = foodDeliveryCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.UtcNow;
            foodDeliveryDbContext.Order.Add(order);
            foodDeliveryDbContext.SaveChanges();

            var items = foodDeliveryCart.ListFoodDeliveryItems;

            foreach(var item in items)
            {
                var orderDetails = new OrderDetails()
                {
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.Price
                };

                foodDeliveryDbContext.OrderDetails.Add(orderDetails);
            }

            foodDeliveryDbContext.SaveChanges();
        }
    }
}
