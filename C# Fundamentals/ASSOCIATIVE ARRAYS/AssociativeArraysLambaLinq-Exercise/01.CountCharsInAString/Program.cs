using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string line = string.Concat(input);

            Dictionary<char, int> count = new Dictionary<char, int>();

            for (int i = 0; i < line.Length; i++)
            {

                if (!count.ContainsKey(line[i]))
                {
                    count.Add(line[i], 1);
                }
                else
                {
                    count[line[i]]++;
                }
            }

            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
