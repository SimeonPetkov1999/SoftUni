using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArrivingInKathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "Last note")
            {
                //^ - asert position
                var Match = Regex.Match(input, @"^([A-Za-z0-9!@#$?]*)=([0-9]*)<<(.*)");
                //^(?<nameofpeak>[A-Za-z0-9!@#$?]+)=(?<length>\d+)<<(?<code>(.*?)+)$
                if (Match.Success == false)
                {
                    Console.WriteLine("Nothing found!");
                    input = Console.ReadLine();
                    continue;
                }
                int lenght = int.Parse(Match.Groups[2].Value);
                if (lenght == Match.Groups[3].Value.Length)
                {
                    string name = string.Empty;
                    foreach (var item in Match.Groups[1].Value)
                    {
                        if (char.IsLetterOrDigit(item))
                        {
                            name += item;
                        }
                    }

                    Console.WriteLine($"Coordinates found! {name} -> {Match.Groups[3].Value}");
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
