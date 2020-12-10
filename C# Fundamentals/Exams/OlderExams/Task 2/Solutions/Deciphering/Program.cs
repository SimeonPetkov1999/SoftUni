using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var match = Regex.Match(input, @"^[d-z{},|#]+");
            string[] toReplace = Console.ReadLine().Split();
            if (match.Success)
            {           
                string decoded = string.Join("", input.Select(n => (char)(n - 3))
                    .ToArray())
                    .Replace(toReplace[0],toReplace[1]);
                Console.WriteLine(decoded);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
