using System;

namespace _10Profit
{
    class Program
    {
        static void Main(string[] args)
        {

            int lev1Coins = int.Parse(Console.ReadLine());
            int lev2Coins = int.Parse(Console.ReadLine());
            int lev5Coins = int.Parse(Console.ReadLine());
            int wantedSum = int.Parse(Console.ReadLine());

            for (int ones = 0; ones <= lev1Coins; ones++)
            {
                for (int twos = 0; twos <= lev2Coins; twos++)
                {
                    for (int fives = 0; fives <= lev5Coins; fives++)
                    {
                        int sum = (ones * 1) + (twos * 2) + (fives * 5);
                        if (sum==wantedSum)
                        {
                            Console.WriteLine($"{ones} * 1 lv. + {twos} * 2 lv. + {fives} * 5 lv. = {wantedSum} lv.");
                        }
                    }
                }
            }
        }
    }
}
