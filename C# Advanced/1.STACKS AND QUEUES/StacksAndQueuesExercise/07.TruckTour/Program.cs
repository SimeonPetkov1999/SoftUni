using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                var infoForPump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                queue.Enqueue(infoForPump);
            }

            int bestPosition = 0;
            while (true)
            {
                bool isFound = true;
                int[] currentPump;
                int fuel = 0;
                for (int i = 0; i < n; i++)
                {
                    currentPump = queue.Dequeue();
                    fuel += currentPump[0];
                    if (fuel < currentPump[1])
                    {
                        isFound = false;
                    }
                    fuel -= currentPump[1];
                    queue.Enqueue(currentPump);
                }
                if (isFound)
                {
                    break;
                }
                bestPosition++;
                queue.Enqueue(queue.Dequeue());
            }
            Console.WriteLine(bestPosition);
        }
    }
}
