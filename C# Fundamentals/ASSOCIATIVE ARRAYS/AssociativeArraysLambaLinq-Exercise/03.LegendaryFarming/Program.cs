using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {         
            Dictionary<string, int> legendaryItems = new Dictionary<string, int>
            {
                {"shards", 0},
                {"fragments", 0},
                {"motes", 0}
            };

            Dictionary<string, int> junk = new Dictionary<string, int>();
            bool isFound= false;
            string itemObtained = string.Empty;
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                for (int i = 0; i < input.Length - 1; i += 2)
                {

                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();
                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        legendaryItems[material] += quantity;

                        if (legendaryItems[material]>=250)
                        {
                            legendaryItems[material] -= 250;
                            isFound = true;
                            if (material=="shards")
                            {
                                itemObtained = "Shadowmourne";
                            }
                            else if (material=="fragments")
                            {
                                itemObtained = "Valanyr";
                            }
                            else
                            {
                                itemObtained = "Dragonwrath";
                            }
                            break;
                        }
                    }
                    else if (!junk.ContainsKey(material))
                    {
                        junk.Add(material, quantity);
                    }
                    else
                    {
                        junk[material] += quantity;
                    }               
                }
                if (isFound)
                {
                    break;
                }
            }
                    
            legendaryItems = legendaryItems
                .OrderByDescending(n => n.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            junk = junk
                .OrderBy(n => n.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"{itemObtained} obtained!");
            foreach (var item in legendaryItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
