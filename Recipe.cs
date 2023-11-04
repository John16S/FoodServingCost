using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodServingCost
{
    internal class Recipe
    {
        public string Name { get; set; }    //Название рецепта
        public List<Product> products { get; set; } //Лист продуктов необх. для рецепта
        public List<double> required_volume { get; set; }   //Лист необх-го объёма каждого продукта
        public int servings { get; set; }   // Кол-во порций
    }
}
