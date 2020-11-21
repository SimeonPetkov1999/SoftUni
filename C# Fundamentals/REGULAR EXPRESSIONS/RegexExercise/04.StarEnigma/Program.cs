using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _04.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexStar = @"[STARstar]";
            string regexPlanets = @"@(?<name>[A-Za-z]+)[^@\-!:>]*:(?<population>[0-9]+)[^@\-!:>]*!([A|D]+)![^@\-!:>]*->[0-9]+";

            StringBuilder sb = new StringBuilder();

            Dictionary<string, List<string>> validPlanets = new Dictionary<string, List<string>>
            {
                {"Attacked", new List<string>()},
                {"Destroyed", new List<string>()}
            };

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Matches(input, regexStar);
                int n = match.Count;

                sb.Append(input);
                for (int j = 0; j < sb.Length; j++)
                {
                    sb[j] = (char)(sb[j] - n);
                }

                input = sb.ToString();

                var matchPlanet = Regex.Match(input, regexPlanets);

                if (matchPlanet.Success)
                {
                    string planetName = matchPlanet.Groups["name"].Value;

                    if (matchPlanet.Groups[1].Value == "A")
                    {
                        validPlanets["Attacked"].Add(planetName);
                    }
                    else if (matchPlanet.Groups[1].Value == "D")
                    {
                        validPlanets["Destroyed"].Add(planetName);
                    }
                }
                sb.Clear();
            }

            Console.WriteLine($"Attacked planets: {validPlanets["Attacked"].Count}");
            foreach (var item in validPlanets["Attacked"].OrderBy(n => n))
            {
                Console.WriteLine($"-> {item}");
            }

            Console.WriteLine($"Destroyed planets: {validPlanets["Destroyed"].Count}");
            foreach (var item in validPlanets["Destroyed"].OrderBy(n => n))
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
