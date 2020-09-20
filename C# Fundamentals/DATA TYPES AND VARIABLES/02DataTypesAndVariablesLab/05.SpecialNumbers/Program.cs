using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumDigits = 0;
            int currentsDigit;

            for (int i = 1; i <= n; i++)
            {
                currentsDigit = i;
                while (currentsDigit > 0)
                {
                    sumDigits += currentsDigit % 10;
                    currentsDigit = currentsDigit / 10;
                }

                bool isSpecial = sumDigits == 5 || sumDigits == 7 || sumDigits == 11;
                Console.WriteLine($"{i} -> {isSpecial}");
                sumDigits = 0;
            }
        }
    }
}
