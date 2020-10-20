using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.VehicleCatalougue
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> input = Console.ReadLine().Split('/').ToList();

            CatalogVehicle catalog = new CatalogVehicle();
            while (input[0]!="end")
            {
                
                if (input[0] == "Car")
                {
                    catalog.Cars.Add(new Car
                    {
                        Brand = input[1],
                        Model = input[2],
                        HorsePower = input[3]
                    });
                }

                else if (input[0] == "Truck")
                {
                    catalog.Trucks.Add(new Truck
                    {
                        Brand = input[1],
                        Model = input[2],
                        Weight = input[3]
                    });
                }

                input = Console.ReadLine().Split('/').ToList();
            }

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine($"Cars:");
                foreach (Car carList in catalog.Cars.OrderBy(car => car.Brand))
                {
                    Console.WriteLine($"{carList.Brand}: {carList.Model} - {carList.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine($"Trucks:");
                foreach (Truck truckList in catalog.Trucks.OrderBy(truck => truck.Brand))
                {
                    Console.WriteLine($"{truckList.Brand}: {truckList.Model} - {truckList.Weight}kg");
                }
            }
        }

        public class Truck 
        {
            public string Brand;
            public string Model;
            public string Weight;
        }
        public class Car 
        {
            public string Brand;
            public string Model;
            public string HorsePower;
        }

        public class CatalogVehicle 
        {       
            public List<Car> Cars;
            public List<Truck> Trucks;

            public CatalogVehicle()
            {
                Cars = new List<Car>();
                Trucks = new List<Truck>();
            }
        }
    }
}
