using System;
using System.Collections.Generic;

using _04.WildFarm.Common;
using _04.WildFarm.Models.FoodModels;


namespace _04.WildFarm.Models.Animals
{
    class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => GlobalConstants.CatWeightIncreaseValue;

        public override ICollection<Type> FoodForAnimal 
        {
            get => new List<Type>
            {
                typeof(Vegetable),
                typeof(Meat)
            };
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
