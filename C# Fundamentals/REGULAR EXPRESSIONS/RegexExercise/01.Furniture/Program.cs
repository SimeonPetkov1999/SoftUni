using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @">>(?<name>[A-Za-z\s]+)<<(?<price>[0-9]*(.\d+)?)[0-9]*!(?<quantity>\d+)";

            string input = Console.ReadLine();

            Dictionary<string, double> allMatches = new Dictionary<string, double>();

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, regex);
                if (match.Success)
                {
                    var type = match.Groups["name"].ToString();
                    double money = double.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["quantity"].Value);
                    allMatches.Add(type, money);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Bought furniture: ");
            foreach (var item in allMatches)
            {
                Console.WriteLine(item.Key);
            }
            double totalSum = allMatches.Values.Sum();
            Console.WriteLine($"Total money spend: {totalSum:f2}");
        }
    }
}
