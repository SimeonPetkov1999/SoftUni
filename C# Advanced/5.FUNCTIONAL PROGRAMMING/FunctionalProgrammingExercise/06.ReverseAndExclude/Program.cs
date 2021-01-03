using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int,int,bool> filter = (n,a) => a % n != 0;

            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();                           
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", numbers
                .Where(a => filter(n, a))
                .Reverse()
                .ToList()));      
        }
    }
}
