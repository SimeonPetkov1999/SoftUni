using System;

namespace _01.ComputerStore
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            double priceNoTaxes = 0;
            double taxes = 0;
            double totalPrice = 0;

            while (input != "regular" && input != "special")
            {
                double money = double.Parse(input);
                if (money < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                priceNoTaxes += money;
                taxes = taxes + (money * 0.20);             
                input = Console.ReadLine();
            }

            totalPrice = priceNoTaxes + taxes;

            if (input=="special")
            {
                totalPrice *= 0.90;
            }

            if (totalPrice==0)
            {
                Console.WriteLine("Invalid order!");
                Environment.Exit(0);
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {priceNoTaxes:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {totalPrice:f2}$");
        }
    }
}
