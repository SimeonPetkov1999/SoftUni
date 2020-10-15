using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MixedUpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> mixedList = new List<int>();


            int minCount = Math.Min(firstNums.Count, secondNums.Count);

            for (int i = 0; i < minCount; i++)
            {
                mixedList.Add(firstNums[i]);
                mixedList.Add(secondNums[secondNums.Count - 1 - i]);
            }

            
            List<int> range = new List<int>();

            if (minCount==secondNums.Count)
            {   
                range = firstNums.GetRange(firstNums.Count - 2, 2);
            }

            else
            {
                range = secondNums.GetRange(0, 2);
            }

            int maxInRange = Math.Max(range[0], range[1]);
            int minInRange = Math.Min(range[0], range[1]);

            List<int> finalList = new List<int>();
            foreach (var item in mixedList)
            {
                if (item > minInRange && item < maxInRange)
                {
                    finalList.Add(item);
                }
            }

            finalList.Sort();

            Console.WriteLine(string.Join(" ",finalList));
        }
    }
}
