using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();
            List<double> biggerThanAverage = new List<double>();
            double average = numbers.Sum() / numbers.Count;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    biggerThanAverage.Add(numbers[i]);
                }
            }
            biggerThanAverage.Sort();
            biggerThanAverage.Reverse();
            if (biggerThanAverage.Count == 0)
            {
                Console.WriteLine("No");
            }
            else if (biggerThanAverage.Count > 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(biggerThanAverage[i] + " ");
                }
            }
            else
            {
                Console.WriteLine(string.Join(" ", biggerThanAverage));
            }
        }
    }
}
