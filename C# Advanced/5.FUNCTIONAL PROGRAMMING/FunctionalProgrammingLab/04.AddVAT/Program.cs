using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.20)
                .Select(x=> x.ToString("f2"))
                .ToList()
                .ForEach(Console.WriteLine);
                 
        }
    }
}
