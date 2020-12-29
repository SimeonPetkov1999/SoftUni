using System;
using System.Collections.Generic;

namespace _04._CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!dictionary.ContainsKey(continent))
                {
                    dictionary.Add(continent, new Dictionary<string, List<string>>());
                    dictionary[continent].Add(country, new List<string>());
                    dictionary[continent][country].Add(city);
                }
                else if (!dictionary[continent].ContainsKey(country))
                {
                    dictionary[continent].Add(country, new List<string>());
                    dictionary[continent][country].Add(city);
                }
                else 
                {
                    dictionary[continent][country].Add(city);
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var city in item.Value)
                {
                    Console.WriteLine($"{city.Key} -> {string.Join(", ",city.Value)}");
                }
            }
        }
    }
}
