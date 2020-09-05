using System;

namespace _02Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            const double priceForLitreGas = 2.10;
            const int priceForEkskurzovod = 100;


            double budget = double.Parse(Console.ReadLine());
            double litresNeeded = double.Parse(Console.ReadLine());
            string weekendDay = Console.ReadLine();

            double priceForGas = priceForLitreGas * litresNeeded;
            double finalPrice = priceForGas + priceForEkskurzovod;

            if (weekendDay == "Saturday")
            {
                finalPrice *= 0.90;
            }

            else
            {
                finalPrice *= 0.80;
            }

            if (finalPrice<=budget)
            {
                double moneyLeft = budget - finalPrice;
                Console.WriteLine($"Safari time! Money left: {moneyLeft:f2} lv.");
            }

            else
            {
                double moneyNeeded = finalPrice - budget;
                Console.WriteLine($"Not enough money! Money needed: {moneyNeeded:f2} lv.");
            }


        }
    }
}
