using System;
using System.Runtime.CompilerServices;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (CheckSum(i) && CheckForOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool CheckSum(int num)
        {
            int sum = 0;

            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }

            if (sum % 8 == 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        static bool CheckForOddDigit(int num)
        {
            int oddDigits = 0;
            int currentDigit = 0;
            while (num != 0)
            {
                currentDigit = num % 10;
                if (currentDigit % 2 != 0)
                {
                    oddDigits++;
                }
                num /= 10;
            }
            if (oddDigits>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
