using System;

namespace _01.CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            int battlesWon = 0;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);             
                if (initialEnergy - distance >= 0)
                {
                    initialEnergy -= distance;
                    battlesWon++;    
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {initialEnergy} energy");
                    Environment.Exit(0);
                }
                if (battlesWon % 3 == 0)
                {
                    initialEnergy += battlesWon;
                }
            }
            Console.WriteLine($"Won battles: {battlesWon}. Energy left: {initialEnergy}");
        }
    }
}
