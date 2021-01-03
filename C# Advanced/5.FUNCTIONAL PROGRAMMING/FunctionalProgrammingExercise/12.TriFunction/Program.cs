using System;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

           
            foreach (var name in names)
            {
                int sum = 0;
                foreach (var ch in name)
                {
                    sum += ch;
                }
                if (sum>=n)
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
