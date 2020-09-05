using System;
using System.Diagnostics;

namespace _03MovieDestination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetForMovie = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int numberOfDays = int.Parse(Console.ReadLine());
            double price = 0;


            if (season=="Winter")
            {
                if (destination=="Dubai")
                {
                    price = 45000;
                }

                else if (destination=="Sofia")
                {
                    price = 17000;
                }
                else
                {
                    price = 24000;
                }
            }
            else
            {
                if (destination == "Dubai")
                {
                    price = 40000;
                }

                else if (destination == "Sofia")
                {
                    price = 12500;
                }
                else
                {
                    price = 20250;
                }
            }

            double finalPrice = numberOfDays * price;

            if (destination=="Dubai")
            {
                finalPrice *= 0.70;
            }

            else if (destination=="Sofia")
            {
                finalPrice *= 1.25;
            }

            double output = Math.Abs(budgetForMovie - finalPrice);

            if (finalPrice<=budgetForMovie)
            {             
                Console.WriteLine($"The budget for the movie is enough! We have {output:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {output:f2} leva more!");
            }
        }
    }
}
