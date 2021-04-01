using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();


            var result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var users = context
                .Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .Select(x => new
                {
                    lastName = x.LastName,
                    age = x.Age,
                    soldProducts = new
                    {
                        count = x.ProductsSold.Count,
                        products = x.ProductsSold.Select(g => new
                        {
                            name = g.Name,
                            price = g.Price,
                        })
                    }
                })
                .OrderByDescending(x=>x.soldProducts.count)
                .ToList();

            var result = new
            {
                usersCount = users.Count,
                users
            };

            var setting = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Average(y => y.Product.Price).ToString("f2"),
                    totalRevenue = x.CategoryProducts.Sum(y => y.Product.Price).ToString("f2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Any(y => y.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Select(y => new
                    {
                        name = y.Name,
                        price = y.Price,
                        buyerFirstName = y.Buyer.FirstName,
                        buyerLastName = y.Buyer.LastName
                    })
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
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

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            foreach (var cp in categoryProducts)
            {
                context.CategoryProducts.Add(cp);
            }

            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            //var usersAsJson = JsonConvert.SerializeObject(users,Formatting.Indented);

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }


    }
}