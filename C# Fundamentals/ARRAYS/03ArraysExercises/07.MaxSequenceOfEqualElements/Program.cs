using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int number=int.MinValue;
            int count = 0;
 
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == numbers[i+1])
                {
                    number = numbers[i];
                    count++;
                }
                else
                {

                }
            }

            for (int i = 0; i <count ; i++)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
