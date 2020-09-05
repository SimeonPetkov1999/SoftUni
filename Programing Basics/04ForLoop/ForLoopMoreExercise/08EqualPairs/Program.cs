using System;

namespace _08EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int value1 = 0;
            int value2 = 0;
            int maxDiff = 0;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    value1 = num1 + num2;
                }

                else
                {
                    value2 = num1 + num2;
                    int diff = Math.Abs(value1 - value2);
                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }


            }

            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value= {value1}");
            }

            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
