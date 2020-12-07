using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var matches = Regex.Matches(input, @"(\|{1}|#{1})(?<itemName>[A-Za-z\s]+)\1(?<date>(?<day>[0-9]{2})\/(?<month>[0-9]{2})\/(?<year>[0-9]{2}))\1(?<cal>[0-9]+)\1");

            int days = matches.Select(n => n.Groups["cal"].Value)
                              .Select(int.Parse)
                              .Sum() / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match item in matches)
            {
                string itemName = item.Groups["itemName"].Value;
                string exDate = item.Groups["date"].Value;
                string cal = item.Groups["cal"].Value;
                Console.WriteLine($"Item: {itemName}, Best before: {exDate}, Nutrition: {cal}");
            }
        }
    }
}
