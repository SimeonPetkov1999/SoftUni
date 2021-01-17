using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Engine
    {

        public void Run() 
        {
            var animals = new List<Animal>();
            while (true)
            {
                var animalType = Console.ReadLine();
                if (animalType == "Beast!")
                {
                    break;
                }
                try
                {
                    AddAnimal(animals, animalType);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            PrintAllAnimals(animals);
        }

        private  void PrintAllAnimals(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private  void AddAnimal(List<Animal> animals, string animalType)
        {
            var animalInfo = Console.ReadLine().Split();
            var animalName = animalInfo[0];
            var animalAge = int.Parse(animalInfo[1]);
            var animalGender = animalInfo[2];

            var currentAnimal = new Animal();

            switch (animalType)
            {
                case "Dog":
                    currentAnimal = new Dog(animalName, animalAge, animalGender);
                    break;
                case "Cat":
                    currentAnimal = new Cat(animalName, animalAge, animalGender);
                    break;
                case "Frog":
                    currentAnimal = new Frog(animalName, animalAge, animalGender);
                    break;
                case "Kitten":
                    currentAnimal = new Kitten(animalName, animalAge);
                    break;
                case "Tomcat":
                    currentAnimal = new Tomcat(animalName, animalAge);
                    break;
            }

            animals.Add(currentAnimal);
        }
    }

   
}
