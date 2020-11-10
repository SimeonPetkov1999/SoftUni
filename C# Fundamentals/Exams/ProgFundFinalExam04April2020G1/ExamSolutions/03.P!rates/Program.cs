using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cities = new Dictionary<string, List<int>>();

            string[] firstCommand = Console.ReadLine().Split("||");

            while (firstCommand[0] != "Sail")
            {
                string currentCity = firstCommand[0];
                int population = int.Parse(firstCommand[1]);
                int gold = int.Parse(firstCommand[2]);

                if (!cities.ContainsKey(currentCity))
                {
                    cities.Add(currentCity, new List<int>());
                    cities[currentCity].Add(population);
                    cities[currentCity].Add(gold);
                }
                else
                {
                    cities[currentCity][0] += population;
                    cities[currentCity][1] += gold;
                }
                firstCommand = Console.ReadLine().Split("||");
            }

            string[] secondsCommands = Console.ReadLine().Split("=>");

            while (secondsCommands[0] != "End")
            {

                if (secondsCommands[0] == "Plunder")
                {
                    string town = secondsCommands[1];
                    int people = int.Parse(secondsCommands[2]);
                    int gold = int.Parse(secondsCommands[3]);

                    if (cities.ContainsKey(town))
                    {
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        cities[town][0] -= people;
                        cities[town][1] -= gold;
                        if (cities[town][0] <= 0 || cities[town][1] <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            cities.Remove(town);
                        }
                    }
                }

                else if (secondsCommands[0] == "Prosper")
                {
                    string town = secondsCommands[1];
                    int gold = int.Parse(secondsCommands[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }

                    else if (cities.ContainsKey(town))
                    {
                        cities[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                    }
                }
                secondsCommands = Console.ReadLine().Split("=>");
            }

            if (cities.Count != 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Values.Count} wealthy settlements to go to:");
                foreach (var kvp in cities.OrderByDescending(n => n.Value[1]).ThenBy(n => n.Key))
                {
                    Console.WriteLine($"{kvp.Key} -> Population: {kvp.Value[0]} citizens, Gold: {kvp.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }


        }
    }
}
