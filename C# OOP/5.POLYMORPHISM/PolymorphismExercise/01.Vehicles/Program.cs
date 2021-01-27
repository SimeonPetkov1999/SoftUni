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
            var busInfo = ReadAndSplitCommand();

            var car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            var truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = ReadAndSplitCommand();

                try
                {
                    if (command[0] == "Drive")
                    {
                        var kmToDrive = double.Parse(command[2]);
                        if (command[1] == "Car")
                        {
                            Console.WriteLine(car.Drive(kmToDrive));
                        }
                        else if (command[1] == "Truck")
                        {
                            Console.WriteLine(truck.Drive(kmToDrive));
                        }
                        else if (command[1] == "Bus")
                        {
                            Console.WriteLine(bus.Drive(kmToDrive));
                        }
                    }
                    else if (command[0] == "DriveEmpty")
                    {
                        var kmToDrive = double.Parse(command[2]);
                        Console.WriteLine(bus.DriveEmpty(kmToDrive));
                    }
                    else if (command[0] == "Refuel")
                    {
                        var toRefuel = double.Parse(command[2]);
                        if (command[1] == "Car")
                        {
                            car.Refuel(toRefuel);
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Refuel(toRefuel);
                        }
                        else if (command[1] == "Bus")
                        {
                            bus.Refuel(toRefuel);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }



        private static string[] ReadAndSplitCommand()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }  
    }
}
