using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(currentNum))
                {
                    dictionary.Add(currentNum, 0);
                }
                dictionary[currentNum]++;
            }

            foreach (var (key,value) in dictionary)
            {
                if (value % 2 == 0)
                {
                    Console.WriteLine(key);
                    break;
                }
            }
        }
    }
}
