using System;

namespace CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int Days = int.Parse(Console.ReadLine());
            int cookers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int gofreti = int.Parse(Console.ReadLine());
            int palachinki = int.Parse(Console.ReadLine());


            double cakePrice = cakes * 45;
            double gofretiPrice = gofreti * 5.80;
            double palachinkiPrice = palachinki * 3.20;
            double SumFor1Day = (cakePrice + gofretiPrice + palachinkiPrice) * cookers;
            double SumForWholeCapaign = SumFor1Day * Days;
            double finalsum = SumForWholeCapaign - (SumForWholeCapaign / 8);

            Console.WriteLine(finalsum);
        }
    }
}
