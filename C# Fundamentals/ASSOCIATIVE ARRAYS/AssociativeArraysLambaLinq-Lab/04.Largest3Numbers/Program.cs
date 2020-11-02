using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(n => n)
                .Reverse()
                .Take(3)
                .ToArray();

            Console.WriteLine(string.Join(" ",numbers));


        }
    }
}
