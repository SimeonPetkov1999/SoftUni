using _04.WildFarm.Common;
using _04.WildFarm.Enumerations;
using _04.WildFarm.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            int foodQuantity = food.Quantity;
            string foodName = food.GetType().Name;
            TigersDogsOwlsFood Food;
            var CanEat = Enum.TryParse(foodName, out Food);
            if (CanEat)
            {
                this.Weight += foodQuantity * GlobalConstants.DogWeightIncreaseValue;
                this.FoodEaten += foodQuantity;
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodName}!");
            }
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
