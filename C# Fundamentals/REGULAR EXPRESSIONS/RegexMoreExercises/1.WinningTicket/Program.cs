using System;
using System.Text.RegularExpressions;

namespace _1.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine()
                .Split(new string[] { ",", " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputLine.Length; i++)
            {
                if (inputLine[i].Length == 20)
                {
                    string leftSide = inputLine[i].Substring(0, 10);
                    string rightSide = inputLine[i].Substring(10, 10);

                    var leftMatch = Regex.Match(leftSide, @"\@{6,}|\${6,}|\^{6,}|\#{6,}");
                    var rightMatch = Regex.Match(rightSide, @"\@{6,}|\${6,}|\^{6,}|\#{6,}");

                    if (leftMatch.Length == 10 && rightMatch.Length == 10)
                    {
                        Console.WriteLine($"ticket \"{inputLine[i]}\" - 10{leftMatch.Groups[0].Value[0]} Jackpot!");
                    }
                    else if (leftMatch.Length >= 6 && rightMatch.Length >= 6)
                    {
                        var min = Math.Min(leftMatch.Length, rightMatch.Length);
                        Console.WriteLine($"ticket \"{inputLine[i]}\" - {min}{leftMatch.Groups[0].Value[0]}");
                     }
                    else
                    {
                        Console.WriteLine($"ticket \"{inputLine[i]}\" - no match");
                     }
                }
                else
                {
                    Console.WriteLine($"invalid ticket");
                }
            }
        }
    }
}
