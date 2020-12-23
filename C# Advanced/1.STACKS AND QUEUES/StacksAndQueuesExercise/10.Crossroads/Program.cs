using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int greenLight;
            int freeWindow;

            var carsQueue = new Queue<string>();
            int totalCars = 0;
            var car = Console.ReadLine();
            while (car != "END")
            {
                greenLight = greenLightDuration;
                freeWindow = freeWindowDuration;
                if (car == "green" && carsQueue.Any())
                {
                    while (carsQueue.Any())
                    {
                        var currentCar = carsQueue.Dequeue();
                        if (currentCar.Length < greenLight)
                        {
                            totalCars++;
                            greenLight -= currentCar.Length;
                        }
                        else if (currentCar.Length > greenLight + freeWindow)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[freeWindow + greenLight]}.");
                            Environment.Exit(0);
                        }
                        else
                        {
                            totalCars++;
                            break;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(car);
                }
                car = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCars} total cars passed the crossroads.");
        }
    }
}
