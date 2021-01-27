using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Interfaces
{
    interface IAnimal 
    {
        public string Name { get;}
        public double Weight { get;}
        public int FoodEaten { get;}

        public string ProduceSound();
    }
}
