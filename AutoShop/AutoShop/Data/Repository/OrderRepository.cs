using AutoShop.Data.Interfaces;
using AutoShop.Models;
using System;

namespace AutoShop.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AutoShopDbContext autoShopDbContext;
        private readonly AutoShopCart autoShopCart;

        public OrderRepository(AutoShopDbContext autoShopDbContext, AutoShopCart autoShopCart)
        {
            this.autoShopDbContext = autoShopDbContext;
            this.autoShopCart = autoShopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.UtcNow;
            autoShopDbContext.Order.Add(order);
            autoShopDbContext.SaveChanges();

            var items = autoShopCart.ListAutoShopItems;

            foreach(var element in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = element.Car.Id,
                    OrderId = order.Id,
                    Price = element.Car.Price
                };

                autoShopDbContext.OrderDetail.Add(orderDetail);
            }

            autoShopDbContext.SaveChanges();
        }
    }
}
