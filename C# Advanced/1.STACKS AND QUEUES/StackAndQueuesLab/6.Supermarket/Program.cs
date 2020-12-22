using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();

            while (true)
            {
                var name = Console.ReadLine();
                if (name=="Paid")
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else if (name=="End")
                {
                    break;
                }
                else
                {
                    queue.Enqueue(name);
                }
              
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
