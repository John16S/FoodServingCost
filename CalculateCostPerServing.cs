using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodServingCost
{
    internal class CalculateCostPerServing
    {
        /// <summary>
        /// Метод который выполняет расчет стоимости одной порции блюда
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public double calculateCostPerServing(Recipe recipe)
        {
            //Если Кол-во проудктов и необх. объемы не равын, то выводим сообщение
            if (recipe.products.Count != recipe.required_volume.Count)
            {
                throw new ArgumentException("Количество продуктов и необходимые объемы должны совпадать!");
            }

            double totalCost = 0;
            for (int i = 0; i < recipe.products.Count; i++)
            {
                //Рассчитываем стоимость одной единицы продукта
                double costPerUnit = recipe.products[i].Price / recipe.products[i].Volume;
                //Умножаем costPerUnit на необходимый объем данного продукта и добавляем это значение к общей стоимости
                totalCost += costPerUnit * recipe.required_volume[i];
            }
            //возвращаем общую стоимость блюда, разделяя totalCost на количество порций
            return totalCost / recipe.servings;
        }
    }
}
