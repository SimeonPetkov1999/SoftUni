using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            long Yield = long.Parse(Console.ReadLine());
            long extractedSpice = 0;
            int days = 0;

            if (Yield<100)
            {
                Console.WriteLine(days);
                Console.WriteLine(extractedSpice);
                Environment.Exit(0);
            }


            while (Yield>99)
            {
                extractedSpice += Yield;
                extractedSpice -= 26;                                          
                Yield -= 10;
                days++;
            }

            Console.WriteLine(days);
            Console.WriteLine(extractedSpice-26);
         }
    }
}
