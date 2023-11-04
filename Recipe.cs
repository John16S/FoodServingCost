using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodServingCost
{
    //Модель для хранение рецепта
    internal class Recipe
    {
        public string Name { get; set; }    //Название рецепта
        public List<Product> Products { get; set; } //Лист продуктов необх. для рецепта
        public List<double> Required_volume { get; set; }   //Лист необх-го объёма каждого продукта
        public int Servings { get; set; }   // Кол-во порций
    }
}
