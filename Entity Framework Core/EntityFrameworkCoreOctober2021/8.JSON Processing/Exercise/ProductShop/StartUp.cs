using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureCreated();

            var usersJson = File.ReadAllText("Datasets/users.json");
            var productsJson = File.ReadAllText("Datasets/products.json");
            var categoriesJson = File.ReadAllText("Datasets/categories.json");
            var categoriesProductsJson = File.ReadAllText("Datasets/categories-products.json");

            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(inputJson).Where(x => x.Name != null);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProduct>>(inputJson);
            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var result = context
                .Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName,
                })
                .OrderBy(x => x.price)
                .ToList();

            var resultAsJson = JsonConvert.SerializeObject(result, Formatting.Indented);
            return resultAsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Select(ps => new
                    {
                        name = ps.Name,
                        price = ps.Price,
                        buyerFirstName = ps.Buyer.FirstName,
                        buyerLastName = ps.Buyer.LastName,
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var usersAsJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            return usersAsJson;

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = x.CategoryProducts
                                    .Average(cp => cp.Product.Price)
                                    .ToString("f2"),
                    totalRevenue = x.CategoryProducts
                                    .Sum(cp => cp.Product.Price)
                                    .ToString("f2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var categoriesJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return categoriesJson;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(ps => ps.Buyer != null))
                .Select(x => new
                {
                    firstName=x.FirstName,
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count,
                        products = x.ProductsSold.Select(ps => new
                        {
                            name = ps.Name,
                            price = ps.Price,
                        })
                    }
                })
                .OrderByDescending(x=>x.soldProducts.count)
                .ToList();

            var usersCount = new
            {
                usersCount = users.Count(),
                users = users,
            };

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(usersCount, settings);

            return json;
        }
    }
}