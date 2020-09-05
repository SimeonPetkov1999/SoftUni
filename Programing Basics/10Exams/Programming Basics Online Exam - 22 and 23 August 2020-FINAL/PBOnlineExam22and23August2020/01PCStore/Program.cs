using System;

namespace _01PCStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceCPU = double.Parse(Console.ReadLine()) * 1.57;
            double priceGraphicsCard = double.Parse(Console.ReadLine()) * 1.57;
            double priceOnePieceOfRam = double.Parse(Console.ReadLine()) * 1.57;
            int numberOfRams = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double finalPriceForRam = priceOnePieceOfRam * numberOfRams;
            priceCPU -= (priceCPU * discount);
            priceGraphicsCard -= (priceGraphicsCard * discount);

            double finalPrice = priceCPU + priceGraphicsCard + finalPriceForRam;
            Console.WriteLine($"Money needed - {finalPrice:f2} leva.");
        }
    }
}
