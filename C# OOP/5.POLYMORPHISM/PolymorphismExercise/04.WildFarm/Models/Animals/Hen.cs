using _04.WildFarm.Common;
using _04.WildFarm.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            int foodQuantity = food.Quantity;
            string foodName = food.GetType().Name;
            this.Weight += foodQuantity * GlobalConstants.HenWeightIncreaseValue;
            this.FoodEaten += foodQuantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
