using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PlantInfo> plants = new Dictionary<string, PlantInfo>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string plantName = input[0];
                int rarity = int.Parse(input[1]);
                if (!plants.ContainsKey(plantName))
                {
                    plants.Add(plantName, new PlantInfo(rarity));
                }
                else
                {
                    plants[plantName].rarity = rarity;
                }
            }


            string[] commandsArgs = Console.ReadLine()
                .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
            while (commandsArgs[0] != "Exhibition")
            {
                string command = commandsArgs[0];
                string plant = commandsArgs[1];
               
                if (command=="Rate")
                {
                    if (plants.ContainsKey(plant))
                    {
                        double rate = double.Parse(commandsArgs[2]);
                        plants[plant].rating.Add(rate);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command=="Update")
                {
                    if (plants.ContainsKey(plant))
                    {
                        int rarity = int.Parse(commandsArgs[2]);
                        plants[plant].rarity = rarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command=="Reset")
                {
                    if (plants.ContainsKey(plant))
                    {
                        plants[plant].rating.Clear();
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                commandsArgs = Console.ReadLine()
                .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in plants)
            {
                if (item.Value.rating.Count != 0)
                {
                    item.Value.averageRating = item.Value.rating.Sum() / item.Value.rating.Count;
                }                
            }

            Console.WriteLine($"Plants for the exhibition:");
            foreach (var item in plants.OrderByDescending(n=>n.Value.rarity).ThenByDescending(n=>n.Value.averageRating))
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.rarity}; Rating: {item.Value.averageRating:f2}");   
            }
        }
    }
    class PlantInfo
    {
        public PlantInfo(int rarity)
        {
            this.rarity = rarity;
            this.rating = new List<double>();
        }
        public int rarity { get; set; }
        public double averageRating { get; set; }
        public List<double> rating { get; set; }
    }
}
