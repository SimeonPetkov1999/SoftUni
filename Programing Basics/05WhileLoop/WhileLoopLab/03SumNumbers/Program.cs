using System;

namespace _03SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int sum = num;
            int currentSum = 0;
            while (true)
            {
                if (currentSum >= sum)
                {
                    Console.WriteLine(currentSum);
                    break;
                }

                num = int.Parse(Console.ReadLine());
                currentSum += num;
            }
        }
    }
}
