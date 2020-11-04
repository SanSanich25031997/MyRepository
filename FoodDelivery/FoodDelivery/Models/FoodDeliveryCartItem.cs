namespace FoodDelivery.Models
{
    public class FoodDeliveryCartItem
    {
        public int Id { get; set; } //Идентификационный номе
        public Product Product { get; set; } //Продукт
        public int Price { get; set; } //Цена
        public string FoodDeliveryCartId { get; set; } //Идентификационный номер продукта
    }
}
