using System;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, @"^(.+)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$");

                if (match.Success)
                {
                    string s1 = match.Groups[2].Value;
                    string s2 = match.Groups[3].Value;
                    string s3 = match.Groups[4].Value;
                    string s4 = match.Groups[5].Value;
                    Console.WriteLine($"Password: {s1}{s2}{s3}{s4}");
                }
                else
                {
                    Console.WriteLine("Try another password!"); 
                }
            }
        }
    }
}
