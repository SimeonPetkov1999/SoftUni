using System;
using System.Linq;
using System.Text;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach (var word in sequence)
            {
                char firstLetter = word[0];
                char lastLetter = word[word.Length - 1];
                double number = double.Parse(word.Substring(1, word.Length - 2));//?

                if (char.IsUpper(firstLetter))
                {
                    number = number / getCharPosition(firstLetter);
                }
                else if (char.IsLower(firstLetter))
                {
                    number = number * getCharPosition(firstLetter);
                }

                if (char.IsUpper(lastLetter))
                {
                    sum += number - getCharPosition(lastLetter);
                }

                else if (char.IsLower(lastLetter))
                {
                    sum += number + getCharPosition(lastLetter);
                }
            }
            Console.WriteLine($"{sum:f2}");
        }
        static double getCharPosition(char a)
        {
            a = char.ToLower(a);
            double positon = (double)a - 96;
            return positon;
        }


    }
}
