using System;

namespace _01ShopingForSchool
{
    class Program
    {
        static void Main(string[] args)
        {

            int packetOfPencis = int.Parse(Console.ReadLine());
            int numberOfMarkers = int.Parse(Console.ReadLine());
            int numberOfBlocks = int.Parse(Console.ReadLine());
            int numberOfBooks = int.Parse(Console.ReadLine());

            double priceForPencils = packetOfPencis * 4.75;
            double priceForMarkers = numberOfMarkers * 1.80;
            double priceForBlocks = numberOfBlocks * 6.50;
            double priceForBooks = numberOfBooks * 2.50;

            double finalPrice = priceForPencils + priceForMarkers + priceForBlocks + priceForBooks;
            finalPrice = finalPrice - (finalPrice * 5 / 100);
            Console.WriteLine($"Your total is {finalPrice:f2}lv");
        }
    }
}
