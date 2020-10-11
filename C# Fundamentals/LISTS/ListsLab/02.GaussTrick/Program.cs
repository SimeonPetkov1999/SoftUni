using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();


            Console.WriteLine(string.Join(" ",SumPairs(numbers)));

        }

        static List<int> SumPairs(List<int> numbers) 
        {
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count/2; i++)
            {
                result.Add(numbers[i] + numbers[numbers.Count-i-1]);
            }
            if (numbers.Count%2!=0)
            {
                result.Add(numbers[numbers.Count / 2]);
            }
            return result;
        }
    }
}
