using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            while (queue.Count>1)
            {
                for (int i = 1; i <= n; i++)
                {
                    if (i==n)
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}");
                    }
                    else
                    {
                        var removed = queue.Dequeue();
                        queue.Enqueue(removed);
                    }
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
