using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int[] bestDna = new int[lenght];
            int bestIndex = int.MinValue;
            int bestSequenceNum = 0;

            while (input!="Clone them!")
            {
                int[] numbers = input.Split('!').Select(int.Parse).ToArray();

                for (int i = 0; i < numbers.Length-1; i++)
                {
                    if (numbers[i] ==1 && numbers[i+1] == 1)
                    {
                        
                    }
                }

            }
        }
    }
}
