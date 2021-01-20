using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var allPeople = new List<Person>();
            var allProducts = new List<Product>();

            var personsInfo = ReadInput(';');
            var productsInfo = ReadInput(';');

            try
            {
                AddAllPeopleToList(allPeople, personsInfo);
                AddAllProdcutsToList(allProducts, productsInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }


            while (true)
            {
                var commandArgs = ReadInput(' ');
                if (commandArgs[0] == "END")
                {
                    break;
                }

                var personName = commandArgs[0];
                var productName = commandArgs[1];

                var person = allPeople.FirstOrDefault(p => p.Name == personName);
                var product = allProducts.FirstOrDefault(p => p.Name == productName);

                try
                {
                    Console.WriteLine(person.AddProduct(product));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Print(allPeople);
        }

        private static void Print(List<Person> allPeople)
        {
            foreach (var person in allPeople)
            {
                var productsBought = person.Bag.Count == 0 ?
                                     "Nothing bought " :
                                     string.Join(", ", person.Bag);
                Console.WriteLine($"{person.Name} - {productsBought}");
            }
        }

        private static void AddAllProdcutsToList(List<Product> allProducts, string[] productsInfo)
        {
            foreach (var product in productsInfo)
            {
                var currentProductInfo = product
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                var productName = currentProductInfo[0];
                var productCost = double.Parse(currentProductInfo[1]);
                
                allProducts.Add(new Product(productName, productCost));
            }
        }
        private static void AddAllPeopleToList(List<Person> allPeople, string[] personsInfo)
        {
            foreach (var person in personsInfo)
            {
                var currentPersonInfo = person
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);
                var personName = currentPersonInfo[0];
                var personMoney = double.Parse(currentPersonInfo[1]);

                allPeople.Add(new Person(personName, personMoney));
            }
        }

        private static string[] ReadInput(char delimeter)
        {
            return Console.ReadLine()
                 .Split(delimeter, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}


