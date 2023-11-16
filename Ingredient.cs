namespace FoodServingCost
{
    //Модель для хранения ингридиентов
    internal class Ingredient
    {
        private Product product;
        private double requiredVolume;

        public Ingredient(Product product, double requiredVolume)
        {
            Product = product;
            RequiredVolume = requiredVolume;
        }

        public Product Product 
        { 
            get => product;
            private set
            {
                if (value == null)
                    throw new Exception("Продукт не может быть null!");
                else
                    product = value;
            } 
        }
        public double RequiredVolume
        {
            get => requiredVolume;
            private set 
            {
                if (value <= 0 || value > product.Volume)
                    throw new Exception("Необходимый объём не может быть 0, отрицательным или больше самого объёма!");
                else
                    requiredVolume = value;
            }
        }
        /// <summary>
        /// Обновляет поле requiredVolume
        /// </summary>
        /// <param name="requiredVolume"></param>
        public void UpdateRequiredVolume(double requiredVolume)
        {
            RequiredVolume = requiredVolume;
        }
    }
}
