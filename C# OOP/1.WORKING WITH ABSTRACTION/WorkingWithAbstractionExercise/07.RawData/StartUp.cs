using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var allCars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var carModel = carInfo[0];
                var speed = double.Parse(carInfo[1]);
                var power = double.Parse(carInfo[2]);
                var weight = double.Parse(carInfo[3]);
                var type = carInfo[4];

                var currentCarEngine = new Engine(speed, power);
                var currentCarCargo = new Cargo(weight, type);
                var curerntCarTire = new Tire[4];
                curerntCarTire[0] = new Tire(double.Parse(carInfo[5]), double.Parse(carInfo[6]));
                curerntCarTire[1] = new Tire(double.Parse(carInfo[7]), double.Parse(carInfo[8]));
                curerntCarTire[2] = new Tire(double.Parse(carInfo[9]), double.Parse(carInfo[10]));
                curerntCarTire[3] = new Tire(double.Parse(carInfo[11]),double.Parse(carInfo[12]));
             
                allCars.Add(new Car(carModel, currentCarEngine, currentCarCargo, curerntCarTire));               
            }
            var command = Console.ReadLine();
            if (command=="flamable")
            {
                allCars = allCars
                    .Where(x => x.Cargo.CargoType == "flamable")
                    .Where(x => x.Engine.EnginePower > 250)
                    .ToList();
            }
            else
            {
                allCars = allCars
                    .Where(x => x.Cargo.CargoType == "fragile")
                    .Where(x => x.Tires.Any(x => x.TirePressure < 1))
                    .ToList();
            }
            foreach (var car in allCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
