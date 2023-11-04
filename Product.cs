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
        public string Name { get; set; }    //Название продукта
        public double Volume { get; set; }  //Объём (количество)
        public double Price { get; set; }   //Стоимость
    }
}
