using System;

namespace _01SuppliesForSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            int packetsOfPens = int.Parse(Console.ReadLine());
            int packetsOfMarkers = int.Parse(Console.ReadLine());
            double litersCleaningWater = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());
           

            double priceForPens = packetsOfPens * 5.80;
            double priceForMarkers = packetsOfMarkers * 7.20;
            double priceForWater = litersCleaningWater * 1.20;

            double finalPrice = (priceForMarkers + priceForPens + priceForWater);
            double finalPriceDiscount = finalPrice - ((finalPrice * discount)/100);

            Console.WriteLine($"{finalPriceDiscount:f3}");

        }
    }
}
