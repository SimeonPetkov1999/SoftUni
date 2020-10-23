using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split();
            List<Vehicle> vehicles = new List<Vehicle>();

            while (input[0] != "End")
            {
                string type = input[0];
                string model = input[1];
                string color = input[2];
                int horsePower = int.Parse(input[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsePower);
                vehicles.Add(vehicle);

                input = Console.ReadLine().Split();
            }

            string car = Console.ReadLine();

            while (car != "Close the Catalogue")
            {
                int index = vehicles.FindIndex(n => n.Model == car);
                string type = string.Empty;
                if (vehicles[index].TypeVehicle == "car")
                {
                    type = "Car";
                }
                else
                {
                    type = "Truck";
                }
                Console.WriteLine($"Type: {type}");
                Console.WriteLine($"Model: {vehicles[index].Model}");
                Console.WriteLine($"Color: {vehicles[index].Color}");
                Console.WriteLine($"Horsepower: {vehicles[index].HorsePower}");
                car = Console.ReadLine();
            }

            List<Vehicle> allCars = vehicles.Where(n => n.TypeVehicle == "car").ToList();
            List<Vehicle> allTrucks = vehicles.Where(n => n.TypeVehicle == "truck").ToList();

            double carHP = allCars.Sum(n => n.HorsePower);
            double truckHP = allTrucks.Sum(n => n.HorsePower);

            double averageHPCars = 0.00;
            double averageHPTrucks = 0.00;

            if (carHP > 0)
            {
                averageHPCars = carHP / allCars.Count;
            }

            if (truckHP > 0)
            {
                averageHPTrucks = truckHP / allTrucks.Count;
            }

            Console.WriteLine($"Cars have average horsepower of: {averageHPCars:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageHPTrucks:f2}.");
        }

        class Vehicle
        {
            public Vehicle(string type, string model, string color, int Hp)
            {
                this.TypeVehicle = type;
                this.Model = model;
                this.Color = color;
                this.HorsePower = Hp;
            }

            public string TypeVehicle { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }

        }
    }
}
