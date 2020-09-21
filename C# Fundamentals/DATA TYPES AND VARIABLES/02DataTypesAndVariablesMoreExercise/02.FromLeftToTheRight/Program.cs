using System;
using System.Numerics;

namespace _02.FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');

                long firstNum = long.Parse(numbers[0]);
                long secondNum = long.Parse(numbers[1]);
                long bigger;

                if (firstNum >= secondNum)
                {
                    bigger = firstNum;
                }
                else
                {
                    bigger = secondNum;
                }

                long sum = 0;
                while (bigger!=0)
                {
                    sum += (bigger % 10);
                    bigger /= 10;
                }

                Console.WriteLine(Math.Abs(sum));
            }
        }
    }
}
