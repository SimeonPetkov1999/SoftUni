using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {   

            List<int> numbers = ReadListOnLine();
            RemoveNagatives(numbers);
            numbers.Reverse();
            if (numbers.Count==0)
            {
                Console.WriteLine("empty");
                Environment.Exit(0);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        static void RemoveNagatives(List<int> numbers) 
        {
            numbers.RemoveAll(item => item < 0);
        }

        static List<int> ReadListOnLine()
        {
           List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            return numbers;

        }
    }
}
