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
        private string name;                    //Название рецепта
        private List<Ingredient> ingredients;   //Лист ингредиентов
        private int servings;                   //Кол-во порций

        public string Name { get => name; set => name = value; }
        public List<Ingredient> Ingredients{ get => ingredients; set => ingredients = value; }
        public int Servings { get => servings; set => servings = value; }


        /// <summary>
        /// Метод который выполняет расчет стоимости одной порции блюда
        /// </summary>
        /// <returns>totalCost</returns>
        public double calculateCostPerServing()
        {
            double totalCost = 0;
            for (int i = 0; i < Ingredients.Count; i++)
            {
                //Рассчитываем стоимость одной единицы продукта
                double costPerUnit = Ingredients[i].Product.Price / Ingredients[i].Product.Volume;
                //Умножаем costPerUnit на необходимый объем данного продукта и добавляем это значение к общей стоимости
                totalCost += costPerUnit * Ingredients[i].RequiredVolume;
            }
            //возвращаем общую стоимость блюда, разделяя totalCost на количество порций
            return totalCost / Servings;
        }
    }
}
