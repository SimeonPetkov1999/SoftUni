using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numberOfCars = 0;
            var queue = new Queue<string>();

            while (true)
            {
                string car = Console.ReadLine();
                if (car =="green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queue.Any())
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            numberOfCars++;
                        }
                    
                    }
                }
                else if (car == "end")
                {
                    Console.WriteLine($"{numberOfCars} cars passed the crossroads.");
                    break;
                }
                else
                {
                    queue.Enqueue(car);
                }
            }
        }
    }
}
