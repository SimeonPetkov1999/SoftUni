using System;

using _04.WildFarm.Models.FoodModels;

namespace _04.WildFarm.Factories
{
    class FoodFactory
    {
        public Food CreateFood(string[] foodInfo)
        {
            Food food = null;
            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);
            if (foodType == "Vegetable")
            {
                return food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                return food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                return food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                return food = new Seeds(quantity);
            }
            throw new InvalidOperationException("Cannot create food...");
        }
    }
}
