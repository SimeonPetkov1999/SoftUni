using System;

namespace _05Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string placeForSleep = "";
            string location = "";
            double price = 0.0;

            if (budget<=1000)
            {
                placeForSleep = "Camp";
                if (season=="Summer")
                {
                    location = "Alaska";
                    price = budget * 0.65;
                }
                else
                {
                    location = "Morocco";
                    price = budget * 0.45;
                }
            }

            else if (budget > 1000 && budget <=3000)
            {
                placeForSleep = "Hut";
                if (season == "Summer")
                {
                    location = "Alaska";
                    price = budget * 0.80;
                }
                else
                {
                    location = "Morocco";
                    price = budget * 0.60;
                }
            }

            else
            {
                placeForSleep = "Hotel";
                if (season == "Summer")
                {
                    location = "Alaska";                  
                }
                else
                {
                    location = "Morocco";                   
                }
                price = budget * 0.90;
            }

            Console.WriteLine($"{location} - {placeForSleep} - {price:f2}");
        }
    }
}
