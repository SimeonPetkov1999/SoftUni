using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < input.Length; i++)
            {
                var match = Regex.Match(input[i], @"^[A-Za-z0-9]+\.?\-?_?[A-Za-z0-9]+@([A-Z\-a-z]+\.[A-Z\-a-z]+\.?[A-Z\-a-z]*)+\b");

                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
