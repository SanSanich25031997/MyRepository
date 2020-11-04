namespace FoodDelivery.Models
{
    public class OrderDetails
    {
        public int Id { get; set; } //Идентификационный номер
        public int OrderId { get; set; } //Номер заказа
        public int ProductId { get; set; } //Номер продукта
        public int Price { get; set; } //Цена
        public virtual Product Product { get; set; } //Продукт
        public virtual Order Order { get; set; } //Заказ

    }
}
