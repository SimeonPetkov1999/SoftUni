using System;

namespace _04SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startOfInterval = int.Parse(Console.ReadLine());
            int EndOfInterval = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combinations = 0;
            bool isFound=false;

            for (int a = startOfInterval; a <= EndOfInterval; a++)
            {
                for (int b = startOfInterval; b <= EndOfInterval; b++)
                {
                    int result = a + b;
                    combinations++;
                    if (result == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combinations} ({a} + {b} = {result})");
                        isFound = true;
                        break;

                    }
                }
                if (isFound)
                {
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNumber}");
            }
        }
    }
}
