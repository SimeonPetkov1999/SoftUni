using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersXml = File.ReadAllText("Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context, usersXml));

            //var productsXml = File.ReadAllText("Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, productsXml));

            //var categoriesXml = File.ReadAllText("Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context, categoriesXml));

            //var categoriesProductsXml = File.ReadAllText("Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsXml));

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersInput = XmlConverter.Deserializer<ImportUserDto[]>(inputXml, "Users", false);

            var users = new List<User>();

            foreach (var user in usersInput)
            {
                users.Add(new User()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age
                });
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productsInput = XmlConverter.Deserializer<ImportProductsDto[]>(inputXml, "Products", false);

            var products = new List<Product>();

            foreach (var product in productsInput)
            {
                products.Add(new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    SellerId = product.SellerId,
                    BuyerId = product.BuyerId,
                });
            }

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}"; ;
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesInput = XmlConverter.Deserializer<ImportCategoryDto[]>(inputXml, "Categories", false).Where(x => x.Name != null);

            var categories = new List<Category>();

            foreach (var category in categoriesInput)
            {
                categories.Add(new Category
                {
                    Name = category.Name
                });
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoriesProductsInput = XmlConverter.Deserializer<ImportCategoryProduct[]>(inputXml, "CategoryProducts", false)
                .Where(x => context.Categories.Any(c => c.Id == x.CategoryId) || context.Products.Any(p => p.Id == x.ProductId));

            var categoriesProd = new List<CategoryProduct>();

            foreach (var cp in categoriesProductsInput)
            {
                categoriesProd.Add(new CategoryProduct()
                {
                    CategoryId = cp.CategoryId,
                    ProductId = cp.ProductId,
                });
            }

            context.CategoryProducts.AddRange(categoriesProd);
            context.SaveChanges();


            return $"Successfully imported {categoriesProd.Count}"; ;
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
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x=>x.Price)
                .Take(10)
                .ToArray();

            var xml = XmlConverter.Serialize<ProductsInRange>(products, "Products");

            return xml;
            
        }

        public static string GetSoldProducts(ProductShopContext context) 
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new SoldProduct
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(ps => new ProductDto
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    }).ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x=>x.FirstName)
                .Take(5)
                .ToArray();

            var xml = XmlConverter.Serialize<SoldProduct[]>(users, "Users");
            return xml;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context) 
        {
            var categories = context.Categories
                .Select(x => new CategoriesCount
                {
                    name = x.Name,
                    count = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Average(x => x.Product.Price),
                    totalRevenue = x.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(x => x.count)
                .ThenBy(x => x.totalRevenue)
                .ToArray();

            var xml = XmlConverter.Serialize<CategoriesCount[]>(categories, "Categories");

            return xml;
        }

        public static string GetUsersWithProducts(ProductShopContext context) 
        {
            var count = context.Users
                .Where(x => x.ProductsSold.Count > 0).Count();

            var users = context.Users.
                Include(x=>x.ProductsSold)
                .ToArray()
                .Where(x=>x.ProductsSold.Count>0)
                .Select(x => new UserInfo
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    SoldProducts = new SoldProducts
                    {
                        count = x.ProductsSold.Count,
                        products = x.ProductsSold.Select(x => new ProductInfo
                        {
                            name = x.Name,
                            price = x.Price
                        })
                        .OrderByDescending(x => x.price)
                        .ToArray()
                    }
                    
                })
                .OrderByDescending(x=>x.SoldProducts.count)
                .Take(10)
                .ToArray();

            var userProducts = new UserProducts()
            {
                users = users,
                count = count
            };

            var xml = XmlConverter.Serialize(userProducts, "Users");
            return xml;
        }


    }
}