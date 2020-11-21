using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexForNumbers = @"\d";
            string regexEmoji = @"(:{2}|\*{2})([A-Z]+[a-z]{2,})\1";
            int coolnes = 1;

            string input = Console.ReadLine();
            var matchNums = Regex.Matches(input, regexForNumbers);
            foreach (Match item in matchNums)
            {
                coolnes *= int.Parse(item.Value);
            }

            var matchEmojies = Regex.Matches(input, regexEmoji);

            List<string> coolOnes = new List<string>();

            foreach (Match item in matchEmojies)
            {
                int sum = 0;
                foreach (var emojiChar in item.Groups[2].Value)
                {
                    sum += emojiChar;
                }
                if (sum > coolnes)
                {
                    coolOnes.Add(item.ToString());
                }
            }
            Console.WriteLine($"Cool threshold: {coolnes}");
            Console.WriteLine($"{matchEmojies.Count} emojis found in the text. The cool ones are:");
            foreach (var item in coolOnes)
            {
                Console.WriteLine(item);
            }

        }
    }
}
