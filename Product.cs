using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodServingCost
{
    //Модель для хранение продуктов
    internal class Product
    {
        string name;        //Название продукта
        double volume;      //Объём (количество)
        double price;       //Стоимость

        public string Name { get => name; set => name = value; }
        public double Volume { get => volume; set => volume = value; }
        public double Price { get => price; set => price = value; }
    }
}
