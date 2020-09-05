using System;
using System.IO;

namespace _04TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string nameOfProduct;
            double priceOfProcuct = 0.0;
            int numberOfProducts = 0;
            double finalPrice = 0.0;


            while (true)
            {
                nameOfProduct = Console.ReadLine();
                if (nameOfProduct == "Stop")
                {
                    Console.WriteLine($"You bought {numberOfProducts} products for {finalPrice:f2} leva.");
                    break;
                }
                numberOfProducts++;
                priceOfProcuct = double.Parse(Console.ReadLine());
                if (numberOfProducts % 3 == 0)
                {
                    priceOfProcuct *= 0.50;
                }
                finalPrice += priceOfProcuct;

                if (finalPrice>budget)
                {
                    double moneyNeeded = finalPrice - budget;
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {moneyNeeded:f2} leva!");
                    break;
                }

            }

        }
    }
}
