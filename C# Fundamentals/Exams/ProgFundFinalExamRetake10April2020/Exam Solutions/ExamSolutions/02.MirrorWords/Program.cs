using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            var pairs = Regex.Matches(line, @"(@|#)(?<left>[A-Za-z]{3,})\1{2}(?<right>[A-Za-z]{3,})\1{1}");
            List<string> mirors = new List<string>();

            if (pairs.Count > 0)
            {
                Console.WriteLine($"{pairs.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine($"No word pairs found!");
            }

            foreach (Match item in pairs)
            {
                string left = item.Groups["left"].Value;
                string right = item.Groups["right"].Value;
                string reversed = ReverseString(right);
                if (reversed == left)
                {
                    mirors.Add(left);
                    mirors.Add(right);
                }

            }
            if (mirors.Count > 0)
            {
                List<string> result = new List<string>();
                for (int i = 0; i < mirors.Count; i += 2)
                {
                    result.Add($"{mirors[i]} <=> {mirors[i + 1]}");
                }
                Console.WriteLine($"The mirror words are: ");
                Console.WriteLine(string.Join(", ", result));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }




        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
