using System;
using System.Collections.Generic;

using _04.WildFarm.Models.Animals.Interfaces;
using _04.WildFarm.Models.FoodModels.Interfaces;

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

        public abstract double WeightMultiplier { get; }
        public abstract ICollection<Type> FoodForAnimal { get;}


        public abstract string ProduceSound();

        public virtual void Eat(IFood food) 
        {
            if (!this.FoodForAnimal.Contains(food.GetType()))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            this.Weight += food.Quantity * WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

    }
}
