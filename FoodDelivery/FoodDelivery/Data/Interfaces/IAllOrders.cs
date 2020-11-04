using FoodDelivery.Models;

namespace FoodDelivery.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
