using System;

namespace _05Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = 0.0;
            string destination = null;
            string placeForSleeping = null;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    price = budget * 0.70;
                    placeForSleeping = "Camp";
                }
                else
                {
                    price = budget * 0.30;
                    placeForSleeping = "Hotel";
                }
            }

            else if (budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    price = budget * 0.60;
                    placeForSleeping = "Camp";
                }
                else
                {
                    price = budget * 0.20;
                    placeForSleeping = "Hotel";
                }
            }

            else
            {
                destination = "Europe";
                price = budget * 0.10;
                placeForSleeping = "Hotel";

            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{placeForSleeping} - {(budget - price):f2}");
        }
    }
}
