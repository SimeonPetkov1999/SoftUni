using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var e = int.Parse(Console.ReadLine());
            var allEngines = new List<Engine>();
            for (int i = 0; i < e; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var power = int.Parse(input[1]);
                if (input.Length == 4)
                {
                    var displacement = int.Parse(input[2]);
                    var efficiency = input[3];
                    allEngines.Add(new Engine(model, power, displacement, efficiency));
                }
                else if (input.Length == 2)
                {
                    allEngines.Add(new Engine(model, power));
                }
                else if (input.Length == 3)
                {
                    //Check what is the third input ( Displacement / Efficiency )
                    if (char.IsDigit(input[2][0]))
                    { 
                        // Displacement
                        var displacement = int.Parse(input[2]);
                        allEngines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        // Efficiency
                        var efficiency = input[2];
                        allEngines.Add(new Engine(model, power, efficiency));
                    }
                }             
            }
            var allCars = new List<Car>();
            var c = int.Parse(Console.ReadLine());
            for (int i = 0; i < c; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = carInfo[0];
                var engineModel = carInfo[1];
                var CarEngine = allEngines
                    .Where(e => e.Model == engineModel)
                    .ToList()
                    .FirstOrDefault();

                if (carInfo.Length == 4)
                {
                    var weight = int.Parse(carInfo[2]);
                    var color = carInfo[3];
                    allCars.Add(new Car(model, CarEngine, weight, color));
                }
                else if (carInfo.Length == 2)
                {
                    allCars.Add(new Car(model, CarEngine));
                }
                else if (carInfo.Length == 3)
                {
                    //Check what is the third input ( Weight / Color )
                    if (char.IsDigit(carInfo[2][0]))
                    {
                        // Weight
                        var weight = int.Parse(carInfo[2]);
                        allCars.Add(new Car(model, CarEngine, weight));
                    }
                    else
                    {
                        // Color
                        var color = carInfo[2];
                        allCars.Add(new Car(model, CarEngine, color));
                    }
                }
            }

            foreach (var car in allCars)
            {
                var currentCarInfo=car.ToString();
                Console.WriteLine(currentCarInfo);
            }

        }
    }
}
