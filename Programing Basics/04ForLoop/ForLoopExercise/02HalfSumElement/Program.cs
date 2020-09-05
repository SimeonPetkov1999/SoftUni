using System;

namespace _02HalfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num>max)
                {
                    max = num;
                }

                sum += num;
            }

            sum -= max;

            if (sum==max)
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {sum}");

            }

            else
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {Math.Abs(sum - max)}");

            }
        }
    }
}
