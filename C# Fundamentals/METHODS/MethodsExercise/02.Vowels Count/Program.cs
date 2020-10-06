using System;

namespace _02.Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetVowelsCount(input));
        }

        static int GetVowelsCount(string input)
        {
            string vowels = "AEIOUaeiou";
            int count = 0;
            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (vowels.Contains(input[i]))
            //    {
            //        count++;
            //    }
            //}
            foreach (char digit in input)
            {
                if (vowels.Contains(digit))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
