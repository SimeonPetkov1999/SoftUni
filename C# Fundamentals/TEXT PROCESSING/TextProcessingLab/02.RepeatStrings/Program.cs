using System;
using System.Text;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string[] input = Console.ReadLine().Split();
            foreach (var word in input)
            {
                string repeated = string.Empty;

                for (int i = 0; i < word.Length; i++)
                {
                    repeated += word;
                }

                result.Append(repeated);
            }
            Console.WriteLine(result);
        }
    }
}
