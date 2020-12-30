using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var countOfSymbols = new SortedDictionary<char, int>();

            foreach (var symbol in input)
            {
                if (!countOfSymbols.ContainsKey(symbol))
                {
                    countOfSymbols.Add(symbol, 0);
                }
                countOfSymbols[symbol]++;
            }

            foreach (var (key,value) in countOfSymbols)
            {
                Console.WriteLine($"{key}: {value} time/s");
            }
            
        }
    }
}
