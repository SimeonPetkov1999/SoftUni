using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersXml = File.ReadAllText("Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context,suppliersXml));

            //var partsXml = File.ReadAllText("Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, partsXml));

            //var carsXml = File.ReadAllText("Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, carsXml));

            //var customersXml = File.ReadAllText("Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersXml));

            //var salesXml = File.ReadAllText("Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, salesXml));

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var input = XmlConverter.Deserializer<ImportSupplierDto[]>(inputXml, "Suppliers", false);

            var suppliers = new List<Supplier>();

            foreach (var supplier in input)
            {
                suppliers.Add(new Supplier()
                {
                    Name = supplier.name,
                    IsImporter = supplier.isImporter
                });
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var inputSuppliers = XmlConverter.Deserializer<ImportPartDto[]>(inputXml, "Parts", false)
                .Where(x => context.Suppliers.Any(y => y.Id == x.supplierId));

            var parts = new List<Part>();

            foreach (var item in inputSuppliers)
            {
                parts.Add(new Part()
                {
                    Name = item.name,
                    Price = item.price,
                    Quantity = item.quantity,
                    SupplierId = item.supplierId,
                });
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsDto = XmlConverter.Deserializer<CarPartDto>(inputXml, "Cars");

            var partIds = context.Parts.Select(x => x.Id).ToArray();
            var cars = new List<Car>();

            foreach (var currentCar in carsDto)
            {
                var distinctedParts = currentCar.parts.Select(x => x.id).Distinct();
                var parts = distinctedParts.Intersect(partIds);

                var car = new Car
                {
                    Make = currentCar.make,
                    Model = currentCar.model,
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

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var cumstomersDto = XmlConverter.Deserializer<ImportCustomersDto>(inputXml, "Customers");
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

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var salesDto = XmlConverter.Deserializer<ImportSaleDto>(inputXml, "Sales");

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

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarWithDistance
                {
                    make = x.Make,
                    model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.make)
                .ThenBy(x => x.model)
                .Take(10)
                .ToList();

            var xml = XmlConverter.Serialize(cars, "cars");

            return xml;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new CarsMakeBmw
                {
                    id = x.Id,
                    model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var xml = XmlConverter.Serialize(cars, "cars");

            return xml;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSupplier
                {
                    id = x.Id,
                    name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToList();

            var xml = XmlConverter.Serialize(suppliers, "suppliers");
            return xml;

        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var parts = context.Cars
                .Select(x => new CarParts
                {
                    make = x.Make,
                    model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    parts = x.PartCars.Select(pc => new DTO.Export.PartDto
                    {
                        name = pc.Part.Name,
                        price = pc.Part.Price
                    })
                    .OrderByDescending(x => x.price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.model)
                .Take(5)
                .ToList();

            var xml = XmlConverter.Serialize(parts, "cars");
            return xml;

        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var sales = context
               .Customers
               .Where(x => x.Sales.Any(y => y.CustomerId == x.Id))
               .Select(x => new SalesByCustomer
               {
                   FullName = x.Name,
                   BoughtCars = x.Sales.Count(),
                   SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
               })
               .OrderByDescending(c => c.SpentMoney)
               .ToArray();

            var xml = XmlConverter.Serialize(sales, "customers");
            return xml;
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
    }
}