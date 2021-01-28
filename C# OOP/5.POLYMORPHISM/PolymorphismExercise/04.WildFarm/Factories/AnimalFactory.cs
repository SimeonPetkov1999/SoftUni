using System;

using _04.WildFarm.Models.Animals;

namespace _04.WildFarm.Factories
{
    class AnimalFactory
    {
        public Animal CreateAnimal(string[] animalInfo)
        {
            Animal animal = null;

            string animalType = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            if (animalType == "Owl" || animalType == "Hen")
            {
                double wingSize = double.Parse(animalInfo[3]);
                if (animalType == "Hen")
                {
                    return animal = new Hen(name, weight, wingSize);
                }
                return animal = new Owl(name, weight, wingSize);
            }

            else if (animalType == "Mouse" || animalType == "Dog")
            {
                string livingRegion = animalInfo[3];

                if (animalType == "Dog")
                {
                    return animal = new Dog(name, weight, livingRegion);
                }

                return animal = new Mouse(name, weight, livingRegion);
            }

            else if (animalType == "Cat" || animalType == "Tiger")
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                if (animalType == "Cat")
                {
                    return animal = new Cat(name, weight, livingRegion, breed);
                }

                return animal = new Tiger(name, weight, livingRegion, breed);
            }

            throw new InvalidOperationException("Cannot create Animal...");
        }
    }
}
