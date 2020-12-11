using System;
using System.Text.RegularExpressions;

namespace MessageDecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, @"^(\$|%)([A-Z][a-z]{2,})\1:\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$");
                if (match.Success)
                {
                    string tag = match.Groups[2].Value;
                    string message = string.Empty;
                    message += (char)int.Parse(match.Groups[3].Value);
                    message += (char)int.Parse(match.Groups[4].Value);
                    message += (char)int.Parse(match.Groups[5].Value);
                    Console.WriteLine($"{tag}: {message}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
