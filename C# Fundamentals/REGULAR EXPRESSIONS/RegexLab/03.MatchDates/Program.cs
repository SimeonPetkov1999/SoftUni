using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\b(?<day>\d{2})([-.\/])(?<mounth>[A-Z]{1}[a-z]{2})(\1)(?<year>\d{4})\b";
            string input = Console.ReadLine();
            var mathes = Regex.Matches(input, regex);

            foreach (Match item in mathes)
            {
                var day = item.Groups["day"].Value;
                var month = item.Groups["mounth"].Value;
                var year = item.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
         }
    }
}
