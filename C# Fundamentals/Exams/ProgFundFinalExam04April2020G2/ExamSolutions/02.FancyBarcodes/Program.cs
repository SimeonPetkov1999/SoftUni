using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {       
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, @"@#+([A-Z]+([a-zA-Z0-9]+){4,}[A-Z])@#+");
                if (match.Success)
                {
                    string group = string.Empty;
                    var numbers = Regex.Matches(input, @"\d");
                    if (numbers.Count==0)
                    {
                        group = "00";
                    }
                    else
                    {
                        foreach (Match item in numbers)
                        {
                            group += item.Value;
                        }
                    }
                    Console.WriteLine($"Product group: {group}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }
        }
    }
}
