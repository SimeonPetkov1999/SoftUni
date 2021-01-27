using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight,string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
        public string LivingRegion { get; private set; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
