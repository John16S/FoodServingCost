namespace FoodServingCost
{
    //Модель для хранение продуктов
    internal class Product
    {
        private string name;        //Название продукта
        private double volume;      //Объём (количество)
        private double price;       //Стоимость

        public string Name { get => name; set => name = value; }
        public double Volume { get => volume; set => volume = value; }
        public double Price { get => price; set => price = value; }
    }
}
