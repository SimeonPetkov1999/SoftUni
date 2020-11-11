using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string heroName = input[0];
                int HP = int.Parse(input[1]);
                int MP = int.Parse(input[2]);

                if (!heroes.ContainsKey(heroName))
                {
                    heroes[heroName] = new List<int>(2);
                    heroes[heroName].Add(HP);
                    heroes[heroName].Add(MP);
                }
            }

            string[] command = Console.ReadLine().Split(" - ");
            while (command[0] != "End")
            {
                string action = command[0];
                if (action == "CastSpell")
                {
                    string heroName = command[1];
                    int MPneeded = int.Parse(command[2]);
                    string spellName = command[3];

                    if (heroes[heroName][1] >= MPneeded)
                    {
                        heroes[heroName][1] -= MPneeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }

                else if (action == "TakeDamage")
                {
                    string heroName = command[1];
                    int damage = int.Parse(command[2]);
                    string attacker = command[3];

                    if (heroes[heroName][0] - damage > 0)
                    {
                        heroes[heroName][0] -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);
                    }
                }
                else if (action == "Recharge")
                {
                    string heroName = command[1];
                    int amount = int.Parse(command[2]);

                    if (heroes[heroName][1] + amount <= 200)
                    {
                        heroes[heroName][1] += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - heroes[heroName][1]} MP!");
                        heroes[heroName][1] = 200;
                    }
                }

                else if (action == "Heal")
                {
                    string heroName = command[1];
                    int amount = int.Parse(command[2]);

                    if (heroes[heroName][0] + amount <= 100)
                    {
                        heroes[heroName][0] += amount;
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} healed for {100 - heroes[heroName][0]} HP!");
                        heroes[heroName][0] = 100;
                    }
                }
                command = Console.ReadLine().Split(" - ");
            }

            foreach (var kvp in heroes.OrderByDescending(n => n.Value[0]).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                Console.WriteLine($"  HP: {kvp.Value[0]}");
                Console.WriteLine($"  MP: {kvp.Value[1]}");

            }
        }
    }
}
