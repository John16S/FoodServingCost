namespace FoodServingCost
{
    //Модель для хранения ингридиентов
    internal class Ingredient
    {
        private Product product;
        private double requiredVolume;

        internal Product Product { get => product; set => product = value; }
        public double RequiredVolume { get => requiredVolume; set => requiredVolume = value; }
    }
}
