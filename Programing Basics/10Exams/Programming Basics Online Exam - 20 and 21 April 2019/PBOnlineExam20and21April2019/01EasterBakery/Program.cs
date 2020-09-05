using System;

namespace _01EasterBakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForFlour = double.Parse(Console.ReadLine());
            double flourKG = double.Parse(Console.ReadLine());
            double sugarKG = double.Parse(Console.ReadLine());
            int packetOfEggs = int.Parse(Console.ReadLine());
            int packetsOfMaq = int.Parse(Console.ReadLine());

            double priceForSugar = priceForFlour * 0.75;
            double priceForPacketOfEggs = priceForFlour * 1.10;
            double priceForPacketOfMaq = priceForSugar * 0.20;

            double FinalPriceForFlour = priceForFlour * flourKG;
            double finalPriceForSugar = priceForSugar * sugarKG;
            double finalPriceForEggs = priceForPacketOfEggs * packetOfEggs;
            double finalPriceForMaq = priceForPacketOfMaq * packetsOfMaq;

            double finalPrice = FinalPriceForFlour + finalPriceForSugar + finalPriceForEggs + finalPriceForMaq;

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
