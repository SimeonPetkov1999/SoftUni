using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                strings.Add(input);
                input = Console.ReadLine();
            }

            foreach (var word in strings)
            {
                string reversed = "";
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    reversed += word[i];
                }
                Console.WriteLine($"{word} = {reversed}");
            }

        }
    }
}
