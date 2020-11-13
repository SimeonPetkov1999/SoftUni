using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder text = new StringBuilder();
            text.Append(input);

            for (int i = 0; i < text.Length-1; i++)
            {
                if (text[i]==text[i+1])
                {
                    text.Remove(i + 1, 1);
                    i--;
                }
            }

            Console.WriteLine(text);

        }
    }
}
