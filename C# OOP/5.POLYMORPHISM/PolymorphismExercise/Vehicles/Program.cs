using _01.Vehicles.Models;
using System;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carInfo = ReadAndSplitCommand();
            var truckInfo = ReadAndSplitCommand();

            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = ReadAndSplitCommand();
                try
                {
                    Drive(car, truck, command);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                if (command[0] == "Refuel")
                {
                    Refuel(car, truck, command);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void Refuel(Car car, Truck truck, string[] command)
        {
            var toRefuel = double.Parse(command[2]);
            if (command[1] == "Car")
            {
                car.Refuel(toRefuel);
            }
            else
            {
                truck.Refuel(toRefuel);
            }
        }

        private static string[] ReadAndSplitCommand()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        private static void Drive(Car car, Truck truck, string[] command)
        {
            if (command[0] == "Drive")
            {
                var kmToDrive = double.Parse(command[2]);
                if (command[1] == "Car")
                {
                    Console.WriteLine(car.Drive(kmToDrive));
                }
                else
                {
                    Console.WriteLine(truck.Drive(kmToDrive));
                }
            }
            
        }
    }
}
