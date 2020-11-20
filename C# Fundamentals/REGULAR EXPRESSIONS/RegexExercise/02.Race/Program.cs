using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexNames = @"[A-Za-z]";
            string regexNumbers = @"[0-9]";


            List<string> names = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> racers = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "end of race")
            {
                int distacnce = 0;
                string name = string.Empty;
                var matchLetters = Regex.Matches(input, regexNames);
                var matchNumbers = Regex.Matches(input, regexNumbers);
                foreach (Match item in matchLetters)
                {
                    name += item.Value;
                }
                foreach (Match item in matchNumbers)
                {
                    distacnce += (int.Parse(item.Value));
                }

                if (names.Contains(name))
                {
                    if (racers.ContainsKey(name) == false)
                    {
                        racers.Add(name, distacnce);
                    }
                    else
                    {
                        racers[name] += distacnce;
                    }
                }

                input = Console.ReadLine();
            }

            ;

            racers = racers.OrderByDescending(n => n.Value).ToDictionary(k => k.Key, v => v.Value);


            // Console.WriteLine($"1st place: {racers.Keys.ElementAt(0)}");
            // Console.WriteLine($"2nd place: {racers.Keys.ElementAt(1)}");
            // Console.WriteLine($"3rd place: {racers.Keys.ElementAt(2)}");

            int place = 1;
            foreach (var racer in racers.Take(3))
            {
                switch (place)
                {
                    case 1:
                        Console.WriteLine($"1st place: {racer.Key}");
                        break;
                    case 2:
                        Console.WriteLine($"2nd place: {racer.Key}");
                        break;
                    case 3:
                        Console.WriteLine($"3rd place: {racer.Key}");
                        break;
                }
                place++;
            }



        }
    }
}
