using System;

namespace _07FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMagnolii = int.Parse(Console.ReadLine());
            int numberOfZumbuli = int.Parse(Console.ReadLine());
            int numberOfRozi = int.Parse(Console.ReadLine());
            int numberOfKaktusi = int.Parse(Console.ReadLine());
            double priceForGift = double.Parse(Console.ReadLine());


            double priceForMagnolii = numberOfMagnolii * 3.25;
            double priceForZumbuli = numberOfZumbuli * 4;
            double priceForRozi = numberOfRozi * 3.50;
            double priceForKaktusi = numberOfKaktusi * 8;

            double finalPrice = (priceForMagnolii + priceForZumbuli + priceForRozi + priceForKaktusi) * 0.95;

            if (finalPrice>=priceForGift)
            {
                finalPrice = Math.Floor(finalPrice - priceForGift);
                Console.WriteLine($"She is left with {finalPrice} leva.");
            }
            else
            {
                finalPrice = Math.Ceiling(priceForGift - finalPrice);

                Console.WriteLine($"She will have to borrow {finalPrice} leva.");
            }
        }
    }
}
