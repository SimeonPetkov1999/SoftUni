using _04.WildFarm.Factories;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.Models.FoodModels;

using System;
using System.Collections.Generic;


namespace _04.WildFarm.Core
{
    class Engine : IEngine
    {
        private AnimalFactory animalFactory;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            var animals = new List<Animal>();

            while (true)
            {
                var animalInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (animalInfo[0] == "End")
                {
                    break;
                }

                var foodInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Animal animal = animalFactory.CreateAnimal(animalInfo);            
                Food food = foodFactory.CreateFood(foodInfo);
               
                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }
    }

}
