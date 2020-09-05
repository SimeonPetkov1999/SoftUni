using System;

namespace _01EasterLunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBreads = int.Parse(Console.ReadLine());
            int numberOfPacketsOfEgss = int.Parse(Console.ReadLine());
            int kgOfBiscuits = int.Parse(Console.ReadLine());

            double priceForBreads = numberOfBreads * 3.20;
            double priceForPacketsOfEggs = numberOfPacketsOfEgss * 4.35;
            double priceForBiscuits = kgOfBiscuits * 5.40;
            double priceForColoringTheEggs = (numberOfPacketsOfEgss * 12) * 0.15;

            double finalPrice = priceForBreads + priceForPacketsOfEggs + priceForBiscuits + priceForColoringTheEggs;

            Console.WriteLine($"{finalPrice:f2}");

        }
    }
}
