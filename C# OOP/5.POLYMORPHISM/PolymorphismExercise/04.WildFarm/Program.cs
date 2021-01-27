using _04.WildFarm.Models;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.FoodModels;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            int lines = 0;


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

                Animal animal = null;
                string animalType = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                if (animalType == "Owl" || animalType == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    if (animalType == "Hen")
                    {
                        animal = new Hen(name, weight, wingSize);
                    }
                    else
                    {
                        animal = new Owl(name, weight, wingSize);
                    }
                   
                }

                else if (animalType == "Mouse" || animalType == "Dog")
                {
                    string livingRegion = animalInfo[3];

                    if (animalType == "Dog")
                    {
                        animal = new Dog(name, weight, livingRegion);
                    }
                    else
                    {
                        animal = new Mouse(name, weight, livingRegion);
                    }
                   
                }

                else if (animalType == "Cat" || animalType == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];

                    if (animalType == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }

                   
                }

                Food food = null;
                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);
                if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(quantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(quantity);
                }

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
