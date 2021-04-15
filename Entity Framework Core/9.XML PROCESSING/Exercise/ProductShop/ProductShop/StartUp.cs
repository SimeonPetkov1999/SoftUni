using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

            //var usersXML = File.ReadAllText("../../../Datasets/users.xml");
            //var usersResult = ImportUsers(db, usersXML);
            //Console.WriteLine(usersResult);

            //var productsXML = File.ReadAllText("../../../Datasets/products.xml");
            //var productsResult = ImportProducts(db, productsXML);

            //var categoriesXML = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoriesResult = ImportCategories(db, categoriesXML);

            //var categoriesProductsXML = File.ReadAllText("../../../Datasets/categories-products.xml");
            //var categoriesProductsResult = ImportCategoryProducts(db, categoriesProductsXML);
            //Console.WriteLine(categoriesProductsResult);


            var result = GetUsersWithProducts(db);
            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context) 
        {
            var products = context
                .Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any())
                .Select(x => new UsersAndProductsDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProducts
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold.Select(ps => new ProductsDTO
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .OrderByDescending(z => z.Price)
                        .ToList()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToList();


            var obj = new FinalUsersDTO
            {
                Count = context.Users.Include(x => x.ProductsSold).ToList() .Where(x => x.ProductsSold.Any()).Count(),
                Users = products
            };

            var serializer = new XmlSerializer(typeof(FinalUsersDTO), new XmlRootAttribute("Users"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var writer = new StringWriter();
            serializer.Serialize(writer, obj, ns);

            return writer.ToString();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context) 
        {
            var categories = context
                .Categories
                .Select(x => new CategoriesByProductsDTO
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<CategoriesByProductsDTO>), new XmlRootAttribute("Categories"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var writer = new StringWriter();
            serializer.Serialize(writer, categories, ns);

            return writer.ToString();
        }

        public static string GetSoldProducts(ProductShopContext context) 
        {
            var products = context
                .Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new SoldProductsDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(ps => new ProductDTO
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    }).ToList()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<SoldProductsDTO>), new XmlRootAttribute("Users"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var writer = new StringWriter();
            serializer.Serialize(writer, products, ns);

            return writer.ToString();
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductsInRange
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + ' ' + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();


            var serializer = new XmlSerializer(typeof(ProductsInRange[]),new XmlRootAttribute("Products"));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var writer = new StringWriter();
            serializer.Serialize(writer, products,ns);

            return writer.ToString();
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoriesProductsDTO[]), new XmlRootAttribute("CategoryProducts"));
            var categoriesDTO = (CategoriesProductsDTO[])serializer.Deserialize(new StringReader(inputXml));

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var item in categoriesDTO.Where(x => context.Categories.Any(c => c.Id == x.CategoryId) &&
                                                     context.Products.Any(p => p.Id == x.ProductId)))
            {
                var categoryProduct = new CategoryProduct() { CategoryId = item.CategoryId, ProductId = item.ProductId };

                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoriesDTO[]), new XmlRootAttribute("Categories"));
            var categoriesDTO = (CategoriesDTO[])serializer.Deserialize(new StringReader(inputXml));

            List<Category> categories = new List<Category>();

            foreach (var currentCategory in categoriesDTO)
            {
                var category = new Category() { Name = currentCategory.Name };
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";

        }


        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportProductsDto[]), new XmlRootAttribute("Products"));
            var productsDTO = (ImportProductsDto[])serializer.Deserialize(new StringReader(inputXml));
            List<Product> listOfProducts = new List<Product>();

            foreach (var currentProduct in productsDTO)
            {
                Product product = new Product()
                {
                    Name = currentProduct.Name,
                    Price = currentProduct.Price,
                    SellerId = currentProduct.SellerId
                };
                if (currentProduct.BuyerId != 0)
                {
                    product.BuyerId = currentProduct.BuyerId;
                }
                listOfProducts.Add(product);
            }

            context.Products.AddRange(listOfProducts);
            context.SaveChanges();

            return $"Successfully imported {listOfProducts.Count}"; ;
        }


        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersXML = XDocument.Parse(inputXml).Root.Elements();
            var users = new List<User>();


            foreach (var user in usersXML)
            {
                var firstName = user.Element("firstName").Value;
                var lastName = user.Element("lastName").Value;
                var age = int.Parse(user.Element("age").Value);
                users.Add(new User() { FirstName = firstName, LastName = lastName, Age = age });
            }

            context.Users.AddRange(users);
            context.SaveChanges();


            return $"Successfully imported {users.Count}";
        }
    }
}