using System;

namespace _05EasterBake
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBreads = int.Parse(Console.ReadLine());

            int sugarUsed=0;
            int flourUsed=0;
            int allSugar=0;
            int allFlour=0;    

            int maxSugar = int.MinValue;
            int maxFlour = int.MinValue;
            

            for (int i = 0; i < numberOfBreads; i++)
            {
                sugarUsed = int.Parse(Console.ReadLine());
                flourUsed = int.Parse(Console.ReadLine());

                if (sugarUsed>maxSugar)
                {
                    maxSugar = sugarUsed;
                }

                if (flourUsed>maxFlour)
                {
                    maxFlour = flourUsed;
                }

                allSugar += sugarUsed;
                allFlour += flourUsed;
            }

            double numberOfSugarPackets = Math.Ceiling(allSugar / 950.0);
            double numberOfFlourPackets = Math.Ceiling(allFlour / 750.0);

            Console.WriteLine($"Sugar: {numberOfSugarPackets}");
            Console.WriteLine($"Flour: {numberOfFlourPackets}");
            Console.WriteLine($"Max used flour is {maxFlour} grams, max used sugar is {maxSugar} grams.");



        }
    }
}
