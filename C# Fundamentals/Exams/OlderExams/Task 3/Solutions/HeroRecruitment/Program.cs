using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroRecruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroesAndSpells = new Dictionary<string, List<string>>();

            string[] commandArgs = Console.ReadLine().Split();

            while (commandArgs[0]!="End")
            {
                string command = commandArgs[0];
                string heroName = commandArgs[1];
                if (command == "Enroll")
                {
                    if (heroesAndSpells.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                    else
                    {
                        heroesAndSpells.Add(heroName, new List<string>());
                    }
                }
                else if (command == "Learn")
                {
                    string spellName = commandArgs[2];

                    if (!heroesAndSpells.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else
                    {
                        if (heroesAndSpells[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }
                        else
                        {
                            heroesAndSpells[heroName].Add(spellName);
                        }
                    }
                }
                else if (command == "Unlearn")
                {
                    string spellName = commandArgs[2];

                    if (!heroesAndSpells.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else
                    {
                        if (!heroesAndSpells[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                        else
                        {
                            heroesAndSpells[heroName].Remove(spellName);
                        }
                    }
                }
                commandArgs = Console.ReadLine().Split();
            }

            Console.WriteLine("Heroes");
            foreach (var item in heroesAndSpells.OrderByDescending(n=>n.Value.Count).ThenBy(n=>n.Key))
            {
                Console.WriteLine($"== {item.Key}: {string.Join(",",item.Value)}");
            }
        }
    }
}
