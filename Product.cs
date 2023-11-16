namespace FoodServingCost
{
    //Модель для хранение продуктов
    internal class Product
    {
        private string name;        //Название продукта
        private double volume;      //Объём (количество)
        private double price;       //Стоимость

        public Product(string name, double volume, double price)
        {
            Name = name;
            Volume = volume;
            Price = price;
        }

        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Введите имя продукта!");
                else
                    name = value; 
            }
        }
        public double Volume 
        { 
            get => volume;
            private set
            {
                if (value <= 0)
                    throw new Exception("Объём не может быть 0 или отрицательным");
                else
                    volume = value;
            }
        }
        public double Price 
        { 
            get => price;
            private set
            {
                if(value < 0)
                    throw new Exception("Стоимость не может быть отрицательным");
                else 
                    price = value;
            }
        }

        /// <summary>
        /// Обновляет поля volume и price
        /// </summary>
        /// <param name="volume"></param>
        /// <param name="price"></param>
        public void UpdateVolumeAndPrice(double volume, double price)
        {
            Volume = volume;
            Price = price;
        }
    }
}
