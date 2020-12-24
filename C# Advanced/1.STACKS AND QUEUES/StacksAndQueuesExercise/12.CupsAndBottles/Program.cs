using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueCups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var stackBottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var totalWastedWater = 0;
            while (true)
            {
                var currentBottle = stackBottles.Peek();
                var currentCup = queueCups.Peek();
                if (currentBottle >= currentCup)
                {
                    stackBottles.Pop();
                    queueCups.Dequeue();
                    totalWastedWater += currentBottle - currentCup;
                }
                else if (currentBottle < currentCup)
                {
                    while (currentBottle < currentCup)
                    {
                        stackBottles.Pop();
                        currentCup -= currentBottle;
                        currentBottle = stackBottles.Peek();
                    }
                    totalWastedWater += currentBottle - currentCup;
                    queueCups.Dequeue();
                    stackBottles.Pop();
                }
                if (stackBottles.Any() == false)
                {
                    Console.WriteLine("Cups: " + string.Join(" ", queueCups));             
                    break;
                }
                if (queueCups.Any() == false)
                {
                    Console.WriteLine("Bottles: " + string.Join(" ", stackBottles));
                    break;
                }
            }
            Console.WriteLine($"Wasted litters of water: {totalWastedWater}");
        }
    }
}
