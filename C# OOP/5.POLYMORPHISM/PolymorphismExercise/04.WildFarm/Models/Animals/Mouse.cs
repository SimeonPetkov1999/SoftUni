using System;
using System.Collections.Generic;

using _04.WildFarm.Common;
using _04.WildFarm.Models.FoodModels;


namespace _04.WildFarm.Models.Animals
{
    class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => GlobalConstants.MouseWeightIncreaseValue;

        public override ICollection<Type> FoodForAnimal
        {
            get => new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit)
            };
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
