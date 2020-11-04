using System;

namespace _01.TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = int.Parse(Console.ReadLine());
            int countOfPlayers = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDay = double.Parse(Console.ReadLine());
            double foodPerDay = double.Parse(Console.ReadLine());

            double totalWater = numberOfDays * countOfPlayers * waterPerDay;
            double totalFood = numberOfDays * countOfPlayers * foodPerDay;


            for (int i = 1; i <= numberOfDays; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                groupEnergy -= energyLoss;

                if (groupEnergy<=0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    Environment.Exit(0);
                }

                if (i % 2 == 0)
                {
                    groupEnergy *= 1.05;
                    totalWater *= 0.70;
                }

                if (i % 3 == 0)
                {
                    totalFood = totalFood - (totalFood / countOfPlayers);
                    groupEnergy *= 1.10;
                }
            }

            Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
        }
    }
}
