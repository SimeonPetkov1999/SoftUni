using System;
using System.Collections.Generic;

using _04.WildFarm.Common;
using _04.WildFarm.Models.FoodModels;

namespace _04.WildFarm.Models.Animals
{
    class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => GlobalConstants.DogWeightIncreaseValue;

        public override ICollection<Type> FoodForAnimal
        {
            get => new List<Type>
            {
                typeof(Meat)
            };
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
