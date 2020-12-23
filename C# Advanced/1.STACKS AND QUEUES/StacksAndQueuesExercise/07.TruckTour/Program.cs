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

            var currentBestPosition = 0;
            var Bestposition = 0;
            var shifts = 0;
            var fuel = 0;
            while (true)
            {
                var currentPump = queue.Dequeue();
                fuel += currentPump[0];
                if (fuel - currentPump[1] < 0)//?
                {
                    queue.Enqueue(currentPump);
                    fuel = 0;
                    shifts = 0;
                    Bestposition = ++currentBestPosition;
                    currentBestPosition = 0; ;
                }
                else
                {
                    fuel -= currentPump[1];
                    queue.Enqueue(currentPump);
                    shifts++;
                    currentBestPosition++;
                    if (shifts == n)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(Bestposition);
        }
    }
}
