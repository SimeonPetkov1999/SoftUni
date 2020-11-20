using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\%([A-Z][a-z]+)\%[^|$.]*<(\w+)>[^|$%.]*\|(\d+)\|(\d+\.?\d*)\$";

            string input = Console.ReadLine();
            double income = 0;
            while (input != "end of shift")
            {
                var match = Regex.Match(input, regex);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    double price = double.Parse(match.Groups[3].Value) * double.Parse(match.Groups[4].Value);
                    Console.WriteLine($"{name}: {product} - {price:f2}");
                    income += price;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {income:F2}");
        }
    }
}
