using System;

namespace _07ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double holidayPrice = double.Parse(Console.ReadLine());
            int numberOfPuzzles = int.Parse(Console.ReadLine());
            int numberOfDolls = int.Parse(Console.ReadLine());
            int numberOfBears = int.Parse(Console.ReadLine());
            int numberOfMinions = int.Parse(Console.ReadLine());
            int numberOfTrucks = int.Parse(Console.ReadLine());

            double priceForPuzzles = numberOfPuzzles * 2.60;
            double priceForDolls = numberOfDolls * 3.00;
            double priceForBears = numberOfBears * 4.10;
            double priceForMinions = numberOfMinions * 8.20;
            double priceFoeTrucks = numberOfTrucks * 2.00;

            int allNumbers = numberOfPuzzles + numberOfDolls + numberOfBears + numberOfMinions + numberOfTrucks;

            double allPrice = priceForPuzzles + priceForDolls + priceForBears + priceForMinions + priceFoeTrucks;

            if (allNumbers >= 50)
            {
                allPrice = allPrice * 0.75;
            }

            allPrice = allPrice * 0.90;

            if (holidayPrice<=allPrice)
            {
                Console.WriteLine($"Yes! {allPrice-holidayPrice:f2} lv left.");
            }

            else
            {
                Console.WriteLine($"Not enough money! {holidayPrice - allPrice:f2} lv needed.");
            }

        }
    }
}
