using System;

namespace _08FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine().ToLower();
            double liters = double.Parse(Console.ReadLine());

            if (fuelType=="diesel")
            {
                if (liters >= 25 )
                {
                    Console.WriteLine($"You have enough {fuelType}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {fuelType}!");
                }
            }

            else if (fuelType == "gasoline")
            {
                if (liters >= 25)
                {
                    Console.WriteLine($"You have enough {fuelType}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {fuelType}!");
                }
            }

            else if (fuelType == "gas")
            {
                if (liters >= 25)
                {
                    Console.WriteLine($"You have enough {fuelType}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {fuelType}!");
                }
            }

            else 
            {
                Console.WriteLine("Invalid fuel!");
            }
            
     
        }
    }
}
