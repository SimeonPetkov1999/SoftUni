using System;

namespace CatWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesForWalkForDay = int.Parse(Console.ReadLine());
            int numberOfWalksPerDay = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());


            int allMinutes = minutesForWalkForDay * numberOfWalksPerDay;

            int burnedCallories = allMinutes * 5;

            if (burnedCallories >= calories / 2)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {burnedCallories}");
            }

            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {burnedCallories}");
            }

        }
    }
}
