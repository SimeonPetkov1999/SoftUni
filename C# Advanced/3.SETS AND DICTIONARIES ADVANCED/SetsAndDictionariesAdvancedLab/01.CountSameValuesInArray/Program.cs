using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var dictionary = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentNum = input[i];
                if (!dictionary.ContainsKey(currentNum))
                {
                    dictionary.Add(currentNum, 1);
                }
                else
                {
                    dictionary[currentNum]++;
                }
            }

            foreach (var (key,value) in dictionary)
            {
                Console.WriteLine($"{key} - {value} times");
            }
        }
    }
}
