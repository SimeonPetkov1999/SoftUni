using System;

namespace _04VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForKgVegetables = double.Parse(Console.ReadLine());
            double priceForKgFruits = double.Parse(Console.ReadLine());
            int KgVegetables = int.Parse(Console.ReadLine());
            int KgFruits = int.Parse(Console.ReadLine());

            double priceForAllVegetables = priceForKgVegetables * KgVegetables;
            double priceForAllFruits = priceForKgFruits * KgFruits;
            double priceInBgn = priceForAllFruits + priceForAllVegetables;
            double priceInEur = priceInBgn / 1.94;

            Console.WriteLine($"{priceInEur:F2}");
     

        }
    }
}
