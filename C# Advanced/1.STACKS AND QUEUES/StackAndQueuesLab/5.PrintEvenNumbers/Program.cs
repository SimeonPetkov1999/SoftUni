using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var queue = new Queue<int>(numbers.Where(n => n % 2 == 0));
            Console.WriteLine(string.Join(", ",queue));

        }
    }
}
