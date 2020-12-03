using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();          
            var destinations = Regex.Matches(input, @"(\/{1}|={1})([A-Z][A-Za-z]{2,})\1");
            int points = 0;
            points = destinations
                .Select(n => n.Groups[2])
                .Select(n => n.Value.Length)
                .ToList()
                .Sum();
            Console.WriteLine("Destinations: " + string.Join(", ",destinations.Select(n=>n.Groups[2])));
            Console.WriteLine($"Travel Points: {points}");      
        }
    }
}
