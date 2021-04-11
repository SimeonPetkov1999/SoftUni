using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var suppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //var suppliersResult = ImportSuppliers(db, suppliers);

            //var parts = File.ReadAllText("../../../Datasets/parts.json");
            //var partsResult = ImportParts(db, parts);

            //var cars = File.ReadAllText("../../../Datasets/cars.json");
            //var carsResult = ImportCars(db, cars);

            //var customers = File.ReadAllText("../../../Datasets/customers.json");
            //var customersResult = ImportCustomers(db, customers);

            //var sales = File.ReadAllText("../../../Datasets/sales.json");
            //var salesResult = ImportSales(db, sales);


            var result = GetLocalSuppliers(db);
            Console.WriteLine(result);


        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
                .Sales
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance,
                    },
                    customerName = x.Customer.Name,
                    x.Discount,
                    price = x.Car.PartCars.Sum(s => s.Part.Price),
                    priceWithDiscount = x.Discount == 0 ? 0 :
                    x.Car.PartCars.Sum(s => s.Part.Price) - (x.Car.PartCars.Sum(s => s.Part.Price) * (x.Discount/100))
                })
                .Take(10)
                .ToList();


            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }


        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sales = context
                .Customers
                .Where(x => x.Sales.Count >= 1)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    spentMoney = x.Sales
                    .Select(s => s.Car.PartCars.Sum(y => y.Part.Price)).Sum()
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return json;
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TravelledDistance
                    },
                    parts = x.PartCars.Select(y => new
                    {
                        y.Part.Name,
                        Price = $"{y.Part.Price:F2}"
                    })
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount=x.Parts.Count,
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Select(x => new
                {
                    x.Name,
                    x.BirthDate,
                    x.IsYoungDriver
                })
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            };


            var json = JsonConvert.SerializeObject(customers, jsonSettings);
            return json;
        }


        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }


        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var input = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

            List<Car> cars = new List<Car>();
            foreach (var currentCar in input)
            {
                Car car = new Car()
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TravelledDistance
                };
                foreach (var partId in currentCar.PartsId)
                {
                    car.PartCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(x => context.Suppliers.Any(y => y.Id == x.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}."; ;
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}.";
        }
    }
}