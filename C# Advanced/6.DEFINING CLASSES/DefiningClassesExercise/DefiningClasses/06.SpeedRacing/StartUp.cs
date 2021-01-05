using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allCars = new Dictionary<string,Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var carModel = carInfo[0];
                var carFuelAmount = double.Parse(carInfo[1]);
                var carFuelConsumption = double.Parse(carInfo[2]);
                allCars.Add(carModel,new Car(carModel, carFuelAmount, carFuelConsumption));
            }
            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (command[0]=="End")
                {
                    break;
                }              
                var model = command[1];
                var amountOfKm = double.Parse(command[2]);
                var car = allCars[model];
                car.Drive(amountOfKm);
            }
            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmout:f2} {car.Value.TraveledDistance}");
            }
        }
    }
}
