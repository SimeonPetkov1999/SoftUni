using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexForNumbers = @"\-?\d+\.?\d*";
            string regexForCharacters = @"[^\d*+\-*\/.]";
            string regexSpecialSymbols = @"[\/\*]";

            List<string> input = Console.ReadLine()
                .Split(new char[] {',',' '},StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, List<double>> demons = new Dictionary<string, List<double>>();

            for (int i = 0; i < input.Count; i++)
            {
                int health = 0;
                double damage = 0;
                var matchHealth = Regex.Matches(input[i], regexForCharacters);
                var matchDamage = Regex.Matches(input[i], regexForNumbers);
                var matchSpecialSymbols = Regex.Matches(input[i], regexSpecialSymbols);

                foreach (Match item in matchHealth)
                {
                    health += char.Parse(item.Value);
                }

                foreach (Match item in matchDamage)
                {
                    double num = double.Parse(item.Value);
                    damage += num;
                }

                foreach (Match item in matchSpecialSymbols)
                {
                    string symbol = item.Value;
                    if (symbol=="*")
                    {
                        damage *= 2;
                    }
                    else if (symbol=="/")
                    {
                        damage /= 2;
                    }                    
                }
                demons.Add(input[i], new List<double>());
                demons[input[i]].Add(health);
                demons[input[i]].Add(damage);
            }
            foreach (var item in demons.OrderBy(n=>n.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value[0]} health, {item.Value[1]:f2} damage");
            }
        }
    }
}
