using WildFarm.Interfaces;
using WildFarm.Food;

namespace WildFarm.Core
{
    public class FoodFactory
    {
        public IFood ProduceFood(string foodType, int foodQuantity)
        {
            IFood food = null;

            if (foodType == "Fruit")
            {
                food = new Fruit(foodQuantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(foodQuantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(foodQuantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(foodQuantity);
            }
            return food;
        }
    }
}
