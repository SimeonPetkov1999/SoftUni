using System;
using System.Globalization;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        if (j == numbers.Length - 1)
                        {
                            Console.Write(numbers[i] + " ");
                        }
                    }
                    else
                    {
                        break;
                    }
                }               
            }
            Console.WriteLine(numbers[numbers.Length-1]);
        }
    }
}
