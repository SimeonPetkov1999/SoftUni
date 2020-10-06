using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetMultipleOfEvenAndOdds(GetSumOfOddDigits(input),GetSumOfEvenDigits(input)));
          }
        static int GetSumOfOddDigits(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='-')
                {
                    continue;
                }
                int currentDigit = int.Parse(input[i].ToString());
                if (currentDigit % 2 != 0)
                {
                    sum += currentDigit;
                }
            }
            return sum;
        }
        static int GetSumOfEvenDigits(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '-')
                {
                    continue;
                }
                int currentDigit = int.Parse(input[i].ToString());
                if (currentDigit % 2 == 0)
                {
                    sum += currentDigit;
                }
            }
            return sum;
        }
        static int GetMultipleOfEvenAndOdds(int odd, int even)
        {
            return odd * even;
        }
    }
}
