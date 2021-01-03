using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
           // Predicate<>

            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            names = names
                .Where(name => name.Length <= n)   
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
