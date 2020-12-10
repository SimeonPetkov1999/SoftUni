using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, @"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]");
                if (match.Success)
                {
                    string command = match.Groups[1].Value;
                    string encryptedMessage = string.Join(" ", match
                        .Groups[2]
                        .Value
                        .Select(n => (int)n)
                        .ToArray());
                    Console.WriteLine($"{command}: {encryptedMessage}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
