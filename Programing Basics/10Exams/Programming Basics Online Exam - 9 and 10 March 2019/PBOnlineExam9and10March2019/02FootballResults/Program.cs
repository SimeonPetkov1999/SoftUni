using System;

namespace _02FootballResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultFirstMatch = Console.ReadLine();
            string resultSecondMatch = Console.ReadLine();
            string resultThirdMatch = Console.ReadLine();
            int wins = 0;
            int loses = 0;
            int draws = 0;

            if ((int)resultFirstMatch[0] > (int)resultFirstMatch[2])
            {
                wins++;
            }

            else if ((int)resultFirstMatch[0] < (int)resultFirstMatch[2])
            {
                loses++;
            }

            else
            {
                draws++;
            }

            if ((int)resultSecondMatch[0] > (int)resultSecondMatch[2])
            {
                wins++;
            }

            else if ((int)resultSecondMatch[0] < (int)resultSecondMatch[2])
            {
                loses++;
            }

            else
            {
                draws++;
            }

            if ((int)resultThirdMatch[0] > (int)resultThirdMatch[2])
            {
                wins++;
            }

            else if ((int)resultThirdMatch[0] < (int)resultThirdMatch[2])
            {
                loses++;
            }

            else
            {
                draws++;
            }


            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($"Drawn games: {draws}");

        }
    }
}
