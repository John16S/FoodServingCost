using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodServingCost
{
    //Класс для расчета стоимости одной порции блюда
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
            double totalCost = 0;
            for (int i = 0; i < recipe.Products.Count; i++)
            {
                //Рассчитываем стоимость одной единицы продукта
                double costPerUnit = recipe.Products[i].Price / recipe.Products[i].Volume;
                //Умножаем costPerUnit на необходимый объем данного продукта и добавляем это значение к общей стоимости
                totalCost += costPerUnit * recipe.RequiredVolume[i];
            }
            //возвращаем общую стоимость блюда, разделяя totalCost на количество порций
            return totalCost / recipe.Servings;
        }
    }
}
