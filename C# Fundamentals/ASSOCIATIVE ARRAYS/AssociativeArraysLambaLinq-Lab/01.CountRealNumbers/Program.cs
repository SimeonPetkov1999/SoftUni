using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToList();

            SortedDictionary<int, int> cont = new SortedDictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!cont.ContainsKey(numbers[i]))
                {
                    cont.Add(numbers[i], 1);
                }
                else
                {
                    cont[numbers[i]]++;
                }
            }

            foreach (var num in cont)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
