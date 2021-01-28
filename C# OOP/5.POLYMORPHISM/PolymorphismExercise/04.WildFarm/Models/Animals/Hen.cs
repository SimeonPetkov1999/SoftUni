﻿using System;
using System.Collections.Generic;

using _04.WildFarm.Common;
using _04.WildFarm.Models.FoodModels;


namespace _04.WildFarm.Models.Animals
{
    class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => GlobalConstants.HenWeightIncreaseValue;

        public override ICollection<Type> FoodForAnimal
        {
            get => new List<Type>
            {
                typeof(Meat),
                typeof(Seeds),
                typeof(Fruit),
                typeof(Vegetable)
            };
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
