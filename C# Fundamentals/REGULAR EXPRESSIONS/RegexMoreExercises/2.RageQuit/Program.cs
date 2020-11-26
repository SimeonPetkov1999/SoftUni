using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            var symbolsMatch = Regex.Matches(inputLine, @"[^0-9]+");
            var digitsmatch = Regex.Matches(inputLine, @"\d+");
            string allSymbols = string.Join("", symbolsMatch).ToLower();
            Dictionary<char, int> uniques = new Dictionary<char, int>();            
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < digitsmatch.Count; i++)
            {
                int timesTorepeat = int.Parse(digitsmatch[i].Value);
                for (int j = 0; j < timesTorepeat; j++)
                {
                    sb.Append(symbolsMatch[i]);
                }
            }
            string output = sb.ToString().ToUpper();
            foreach (var item in output)
            {
                if (!uniques.ContainsKey(item))
                {
                    uniques.Add(item, 1);
                }
            }
            Console.WriteLine($"Unique symbols used: {uniques.Count}");
            Console.WriteLine(output);
        }
    }
}
