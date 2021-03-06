﻿using CarDealer.Data;
using System.IO;
using CarDealer.DTO.Input;
using CarDealer.XmlHelper;
using System;
using System.Linq;
using CarDealer.Models;
using System.Collections.Generic;
using CarDealer.DTO.Output;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //ImportSuppliers(context, suppliersXml);

            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //ImportParts(context, partsXml);

            //var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //ImportCars(context, carsXml);

            //var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //ImportCustomers(context, customersXml);


            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context) 
        {
            var result = context
               .Sales
               .Select(x => new OutputSalesWithAppliedDiscount
               {
                   Car = new CarInfo
                   {
                       Make = x.Car.Make,
                       Model = x.Car.Model,
                       TravelledDistance = x.Car.TravelledDistance
                   },
                   Discount = x.Discount,
                   CustomerName = x.Customer.Name,
                   Price = x.Car.PartCars.Sum(x => x.Part.Price),
                   PriceWithDiscount = (x.Car.PartCars.Sum(x => x.Part.Price) - (x.Car.PartCars.Sum(x => x.Part.Price) * x.Discount / 100))

               })
               .ToList();

            var XML = XmlConverter.Serialize(result, "sales");

            return XML;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context) 
        {
            var sales = context
                .Customers
                .Where(x => x.Sales.Count>0)
                .Select(x => new OutputTotalSalesByCustomer
                {
                    Name = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            var xml = XmlConverter.Serialize(sales, "customers");
            return xml;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context) 
        {
            var cars = context
                .Cars
                .Select(x => new OutputCarsWithParts
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(pc => new PartsInfo
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(x => x.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var xml = XmlConverter.Serialize(cars, "cars");
            return xml;
        }

        public static string GetLocalSuppliers(CarDealerContext context) 
        {
            var suppliers = context
                .Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new OutputLocalSuppliers
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            var Xml = XmlConverter.Serialize(suppliers, "suppliers");

            return Xml;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context) 
        {
            var cars = context
                .Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new OutputCarsBmw
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravlledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravlledDistance)
                .ToArray();

            var xml = XmlConverter.Serialize(cars, "cars");

            return xml;
        }

        public static string GetCarsWithDistance(CarDealerContext context) 
        {
            var cars = context
                .Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new OutputCarsWithDistance
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var Xml = XmlConverter.Serialize(cars, "cars");

            return Xml;
        }


        public static string ImportSales(CarDealerContext context, string inputXml) 
        {
            var salesDto = XmlConverter.Deserializer<ImportSales>(inputXml, "Sales");

            var carIds = context.Cars.Select(x => x.Id).ToList();

            var sales = salesDto
                .Where(x => carIds.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml) 
        {
            var cumstomersDto = XmlConverter.Deserializer<ImportCustomers>(inputXml, "Customers");
            var customers = cumstomersDto
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYongDriver
                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml) 
        {
            var carsDto = XmlConverter.Deserializer<ImportCars>(inputXml, "Cars");

            var partIds = context.Parts.Select(x => x.Id).ToArray();
            var cars = new List<Car>();

            foreach (var currentCar in carsDto)
            {
                var distinctedParts = currentCar.PartsIds.Select(x => x.Id).Distinct();
                var parts = distinctedParts.Intersect(partIds);

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TraveledDistance
                };

                foreach (var id in parts)
                {
                    var partCar = new PartCar
                    {
                        PartId = id
                    };

                    car.PartCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}"; ;
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsDto = XmlConverter.Deserializer<ImportParts>(inputXml, "Parts");

            var supplierIds = context.Suppliers.Select(x => x.Id).ToList();

            var parts = partsDto
                .Where(x => supplierIds.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var suppliersDTO = XmlConverter.Deserializer<ImportSuppliers>(inputXml, "Suppliers");

            var suppliers = suppliersDTO.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            });

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count()}";
        }


    }
}