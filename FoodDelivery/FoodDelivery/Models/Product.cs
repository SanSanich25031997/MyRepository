namespace FoodDelivery.Models
{
    public class Product
    {
        public int Id { get; set; } //Идентификационный номер
        public string Name { get; set; } //Название продукта
        public string Description { get; set; } //Описание
        public string Image { get; set; } //Картинка продукта
        public int Price { get; set; } //Цена
        public bool IsFavorite { get; set; } //Входит ли в лучшие продукты
        public bool IsAvailable { get; set; } //Доступен ли продукт
        public virtual Company Company { get; set; } //Компания

    }
}
