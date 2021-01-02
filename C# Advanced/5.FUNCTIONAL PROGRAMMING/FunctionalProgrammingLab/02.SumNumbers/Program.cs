using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console
                 .ReadLine()
                 .Split(", ")
                 .Select(int.Parse)
                 .ToArray();
            Console.WriteLine(input.Length);
            Console.WriteLine(input.Sum());
        }
    }
}
