using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = (name) => 
            {
                Console.WriteLine("Sir " + name);
            };

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);
        }
    }
}
