using System;

namespace _04FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());
            double price = 0.0;

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    price = 4200;
                    break;
                default:
                    price = 2600;
                    break;
            }

            if (fishermans <= 6)
            {
                price *= 0.90;
            }
            else if (fishermans > 6 && fishermans <= 11)
            {
                price *= 0.85;
            }
            else
            {
                price *= 0.75;
            }

            if (season != "Autumn" && fishermans % 2 == 0)
            {
                price *= 0.95;
            }

            if (price<=budget)
            {
                Console.WriteLine($"Yes! You have {budget - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price-budget:f2} leva.");
            }

        }
    }
}
