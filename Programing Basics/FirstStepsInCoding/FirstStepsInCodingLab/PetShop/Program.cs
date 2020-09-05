using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfDogs = int.Parse(Console.ReadLine());
            int numOfAnimals = int.Parse(Console.ReadLine());

            double sum = numOfDogs * 2.50 + numOfAnimals * 4;

            Console.WriteLine($"{sum} lv.");
        }
    }
}
