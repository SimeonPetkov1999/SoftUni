using System;

namespace _01TennisEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceForTennisRacket = double.Parse(Console.ReadLine());
            int numberOfTennisRackets = int.Parse(Console.ReadLine());
            int pairOfShoes = int.Parse(Console.ReadLine());

            double finalPriceForRackets = numberOfTennisRackets * priceForTennisRacket;
            double finalPriceForPairOfShoes = (priceForTennisRacket / 6) * pairOfShoes;
            double finalPriceForOther = (finalPriceForPairOfShoes + finalPriceForRackets) * 0.2;
            double finalPrice = finalPriceForRackets + finalPriceForPairOfShoes + finalPriceForOther;
            double priceForDjokovic = finalPrice / 8.0;
            double finalPriceForSponsors = finalPrice * (7.0 / 8);

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceForDjokovic)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(finalPriceForSponsors)}");

        }
    }
}
