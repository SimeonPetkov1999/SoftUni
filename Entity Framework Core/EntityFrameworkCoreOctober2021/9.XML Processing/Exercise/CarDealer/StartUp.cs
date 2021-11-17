using CarDealer.Data;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;

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
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var input = XmlConverter.Deserializer<ImportSupplierDto[]>(inputXml, "Suppliers", false);

            var suppliers = new List<Supplier>();

            foreach (var supplier in input)
            {
                suppliers.Add(new Supplier()
                {
                    Name = supplier.Name,
                    IsImporter = supplier.IsImporter
                });
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";

        }

    }
}