using _04.WildFarm.Models.Animals.Interfaces;
using _04.WildFarm.Models.FoodModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
              
        }
        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }
        public abstract string ProduceSound();

        public virtual void Eat(Food food) 
        {
            
        }

    }
}
