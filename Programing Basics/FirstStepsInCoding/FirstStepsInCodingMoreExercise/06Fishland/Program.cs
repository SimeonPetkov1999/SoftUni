using System;

namespace _06Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double skumriqPriceKg = double.Parse(Console.ReadLine());
            double cacaPriceKg = double.Parse(Console.ReadLine());
            double palamudKg = double.Parse(Console.ReadLine());
            double safridKg = double.Parse(Console.ReadLine());
            int midiKg = int.Parse(Console.ReadLine());


            double priceForPalamud = skumriqPriceKg + (skumriqPriceKg * 0.60);
            double finalPricePlamud = priceForPalamud * palamudKg;

            double priceForSafrid = cacaPriceKg + (cacaPriceKg * 0.80);
            double finalPriceCaca = priceForSafrid * safridKg;

            double finalPriceForMidi = midiKg * 7.50;

            double finalPrice = finalPriceCaca + finalPriceForMidi + finalPricePlamud;
            Console.WriteLine($"{finalPrice:F2}");

        }
    }
}
