using System;
using System.Text.RegularExpressions;

namespace BossRush
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, @"\|([A-Z]{4,})\|:#([A-Za-z]+\s[A-Za-z]+)#");
                if (match.Success)
                {
                    string bossName = match.Groups[1].Value;
                    string tittle = match.Groups[2].Value;
                    int lenghtName = match.Groups[1].Value.Length;
                    int lenghtTitle = match.Groups[2].Value.Length;
                    Console.WriteLine($"{bossName} The {tittle}");
                    Console.WriteLine($">> Strength: {lenghtName}");
                    Console.WriteLine($">> Armour: {lenghtTitle}");
                }
                else 
                {
                    Console.WriteLine($"Access denied!");
                }
            }
        }
    }
}
