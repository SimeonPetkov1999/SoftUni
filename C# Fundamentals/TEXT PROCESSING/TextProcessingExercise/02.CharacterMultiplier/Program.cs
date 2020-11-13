using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string str1 = input[0];
            string str2 = input[1];

            Console.WriteLine(SumOfStrings(str1,str2));
        }

        static int SumOfStrings(string str1, string str2)
        {
            int sum = 0;

            if (str1.Length==str2.Length)
            {
                for (int i = 0; i < Math.Min(str1.Length, str2.Length); i++)
                {
                    sum += str1[i] * str2[i];
                }
            }
            else
            {
                int i = 0;
                for (i = 0; i < Math.Min(str1.Length, str2.Length); i++)
                {
                    sum += str1[i] * str2[i];
                }
                string bigger = string.Empty;
                if (str1.Length>str2.Length)
                {
                    bigger = str1;
                }
                else
                {
                    bigger = str2;
                }
                for (int j = i; j < Math.Max(str1.Length, str2.Length); j++)
                {
                    sum +=bigger[j];
                }
            }
            

            return sum;
        }
    }
}
