using _04.WildFarm.Common;
using _04.WildFarm.Enumerations;
using _04.WildFarm.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            int foodQuantity = food.Quantity;
            string foodName = food.GetType().Name;
            CatsFood Food;
            var CanEat = Enum.TryParse(foodName, out Food);
            if (CanEat)
            {
                this.Weight += foodQuantity * GlobalConstants.CatWeightIncreaseValue;
                this.FoodEaten += foodQuantity;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodName}!");
            }
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
