using System;
using System.Text.RegularExpressions;

namespace TheIsleOfManTTRace
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {           
                var Match = Regex.Match(input, @"^(#|\$|%|\*|&)([A-Za-z]*)\1=([0-9]*)!!(.*)");          
                if (Match.Success == false)
                {
                    Console.WriteLine("Nothing found!");
                    input = Console.ReadLine();
                    continue;
                }
                int lenght = int.Parse(Match.Groups[3].Value);
                if (lenght == Match.Groups[4].Value.Length)
                {
                    string decoded = string.Empty;
                    foreach (var item in Match.Groups[4].Value)
                    {
                        decoded += (char)(item + lenght);
                    }
                    Console.WriteLine($"Coordinates found! {Match.Groups[2]} -> {decoded}");
                    break;
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }


                input = Console.ReadLine();
            }
        }
    }
}
