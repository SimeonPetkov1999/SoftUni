using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var mathes = Regex.Matches(Console.ReadLine(), @"\+(359)(-| )(2{1})(\2)(\d{3})(\2)(\d{4})\b");
            Console.WriteLine(string.Join(", ", mathes));
        }
    }
}
