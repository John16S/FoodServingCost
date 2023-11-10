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
        string name;                    //Название рецепта
        List<Product> products;         //Лист продуктов необх. для рецепта
        List<double> requiredVolume;    //Лист необх-го объёма каждого продукта
        int servings;                   // Кол-во порций

        public string Name { get => name; set => name = value; }
        public List<double> RequiredVolume { get => requiredVolume; set => requiredVolume = value; }
        public int Servings { get => servings; set => servings = value; }
        public List<Product> Products { get => products; set => products = value; }
    }
}
