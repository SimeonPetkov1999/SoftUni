using System;
using System.Threading;

namespace _06Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int foodKg = int.Parse(Console.ReadLine());
            double foodForDogKG = double.Parse(Console.ReadLine());
            double foodForCatKG = double.Parse(Console.ReadLine());
            double foodForTurtleKG = double.Parse(Console.ReadLine()) / 1000;

            double foodNeededForDog = days * foodForDogKG;
            double foodNeededForCat = days * foodForCatKG;
            double foodNeededForTurtle = days * foodForTurtleKG;

            double allFood = foodNeededForDog + foodNeededForCat + foodNeededForTurtle;

            if (allFood<=foodKg)
            {
                allFood = Math.Floor(foodKg - allFood);
                Console.WriteLine($"{allFood} kilos of food left.");
            }

            else
            {
                allFood = Math.Ceiling(allFood - foodKg);
                Console.WriteLine($"{allFood} more kilos of food are needed.");
            }
        }
    }
}
