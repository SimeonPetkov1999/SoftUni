using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
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

            //var suppliersJson = File.ReadAllText("Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(db, suppliersJson));

            //var partsJson = File.ReadAllText("Datasets/parts.json");
            //Console.WriteLine(ImportParts(db, partsJson));

            //var carsJson = File.ReadAllText("Datasets/cars.json");
            //Console.WriteLine(ImportCars(db, carsJson));

            //var customersJson = File.ReadAllText("Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(db, customersJson));

            //var salesJson = File.ReadAllText("Datasets/sales.json");
            //Console.WriteLine(ImportSales(db, salesJson));

            Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers.AsNoTracking().Select(x => x.Id).ToArray();
            var parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson)
                .Where(x => supplierIds.Contains(x.SupplierId));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}."; ;
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
                foreach (var partId in currentCar.PartsId.Distinct())
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

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();


            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context) 
        {
            var customers = context.Customers
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

        public static string GetCarsFromMakeToyota(CarDealerContext context) 
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context) 
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count,
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context) 
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        x.Model,
                        x.TravelledDistance,
                    },
                    parts = x.PartCars.Select(ps => new
                    {
                        Name = ps.Part.Name,
                        Price = ps.Part.Price.ToString("F2")
                    })
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context) 
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count(),
                    spentMoney = x.Sales.SelectMany(y => y.Car.PartCars.Select(z => z.Part.Price)).Sum()
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;

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
                    x.Car.PartCars.Sum(s => s.Part.Price) - (x.Car.PartCars.Sum(s => s.Part.Price) * (x.Discount / 100))
                })
                .Take(10)
                .ToList();


            var json = JsonConvert.SerializeObject(sales);

            return json;
        }
    }
}