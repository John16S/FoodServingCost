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
        private List<Product> products;         //Лист продуктов необх. для рецепта
        private List<double> requiredVolume;    //Лист необх-го объёма каждого продукта
        private int servings;                   // Кол-во порций

        public string Name { get => name; set => name = value; }
        public List<double> RequiredVolume { get => requiredVolume; set => requiredVolume = value; }
        public int Servings { get => servings; set => servings = value; }
        public List<Product> Products { get => products; set => products = value; }


        /// <summary>
        /// Метод который выполняет расчет стоимости одной порции блюда
        /// </summary>
        /// <returns>totalCost</returns>
        public double calculateCostPerServing()
        {
            double totalCost = 0;
            for (int i = 0; i < products.Count; i++)
            {
                //Рассчитываем стоимость одной единицы продукта
                double costPerUnit = products[i].Price / products[i].Volume;
                //Умножаем costPerUnit на необходимый объем данного продукта и добавляем это значение к общей стоимости
                totalCost += costPerUnit * requiredVolume[i];
            }
            //возвращаем общую стоимость блюда, разделяя totalCost на количество порций
            return Math.Round((totalCost / servings), 2);
        }
    }
}
