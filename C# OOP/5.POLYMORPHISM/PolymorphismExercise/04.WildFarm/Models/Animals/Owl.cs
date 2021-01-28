using System;
using System.Collections.Generic;

using _04.WildFarm.Common;
using _04.WildFarm.Models.FoodModels;

namespace _04.WildFarm.Models.Animals
{
    class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => GlobalConstants.OwlWeightIncreaseValue;

        public override ICollection<Type> FoodForAnimal
        {
            get => new List<Type> 
            { 
                typeof(Meat) 
            };
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
