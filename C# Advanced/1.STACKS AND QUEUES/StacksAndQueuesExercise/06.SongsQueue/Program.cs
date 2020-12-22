using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>(Console.ReadLine().Split(", "));

            while (queue.Any())
            {
                var command = Console.ReadLine();
                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));
                }
                else
                {
                    var toAdd = command.Substring(4,command.Length - 4);
                    if (queue.Contains(toAdd) == false)
                    {
                        queue.Enqueue(toAdd);
                    }
                    else
                    {
                        Console.WriteLine($"{toAdd} is already contained!");
                    }
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
