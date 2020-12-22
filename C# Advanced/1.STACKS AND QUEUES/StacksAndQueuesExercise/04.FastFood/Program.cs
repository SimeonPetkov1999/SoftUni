using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var quantityOfFood = int.Parse(Console.ReadLine());
            var queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var max = queue.Max();
            while (queue.Any())
            {
                if (quantityOfFood >= queue.Peek())
                {
                    quantityOfFood -= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine(max);
                    Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
                    Environment.Exit(0);
                }
            }

            Console.WriteLine(max);
            Console.WriteLine("Orders complete");
        }
    }
}
