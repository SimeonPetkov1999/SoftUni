using System;
using System.Collections.Generic;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sortedSet = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var currentLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in currentLine)
                {
                    sortedSet.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ",sortedSet));
        }
    }
}
