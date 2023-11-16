namespace FoodServingCost
{
    //Модель для хранение рецепта
    internal class Recipe
    {
        private string name;                    //Название рецепта
        private List<Ingredient> ingredients;   //Лист ингредиентов
        private double servings;                   //Кол-во порций

        public Recipe(string name, List<Ingredient> ingredients, double servings)
        {
            Name = name;
            Ingredients = ingredients;
            Servings = servings;
        }

        public string Name 
        { 
            get => name; 
            private set => name = value; 
        }
        public List<Ingredient> Ingredients
        { 
            get => ingredients;
            private set
            { 
                if(value == null)
                    throw new Exception("Список ингредиентов не может быть пустым");
                else
                    ingredients = value;
            }
        }
        public double Servings 
        { 
            get => servings;
            private set
            { 
                if (value <= 0)
                    throw new Exception("Неправильное количество порций");
                else
                    servings = value;
            } 
        }


        /// <summary>
        /// Метод который выполняет расчет стоимости одной порции блюда
        /// </summary>
        /// <returns>totalCost</returns>
        public double calculateCostPerServing()
        {
            double totalCost = 0;   //общий расход на одну порцию
            double priceForOneServ; //итоговая цена + проценты
            for (int i = 0; i < Ingredients.Count; i++)
            {
                //Рассчитываем стоимость одной единицы продукта
                double costPerUnit = Ingredients[i].Product.Price / Ingredients[i].Product.Volume;
                //Умножаем costPerUnit на необходимый объем данного продукта и добавляем это значение к общей стоимости
                totalCost += costPerUnit * Ingredients[i].RequiredVolume;
            }

            //возвращаем общую стоимость блюда, разделяя на количество порций + сверху 25% расхода
            priceForOneServ = (totalCost / Servings) + (totalCost / 4);
            return priceForOneServ;
        }
    }
}
