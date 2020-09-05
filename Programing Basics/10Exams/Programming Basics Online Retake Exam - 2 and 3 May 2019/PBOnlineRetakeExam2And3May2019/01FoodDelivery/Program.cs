using System;

namespace _01FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            const double chickenMenu = 10.35;
            const double fishMenu = 12.40;
            const double vegatarianMenu = 8.15;
            const double priceForDelivery = 2.50;

            int numberOfChickenMenus = int.Parse(Console.ReadLine());
            int numberOfFishMenus = int.Parse(Console.ReadLine());
            int numberOfVegatarianMenus = int.Parse(Console.ReadLine());

            double finalPrice = numberOfChickenMenus * chickenMenu + numberOfFishMenus * fishMenu + numberOfVegatarianMenus * vegatarianMenu;
            double priceForDessert = finalPrice * 0.20;
            finalPrice += priceForDelivery + priceForDessert;

            Console.WriteLine($"Total: {finalPrice:f2}");





        }
    }
}
