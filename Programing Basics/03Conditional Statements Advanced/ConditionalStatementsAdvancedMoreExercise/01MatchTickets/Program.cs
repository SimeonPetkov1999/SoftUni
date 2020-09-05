using System;
using System.Data.SqlTypes;

namespace _01MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int numberOfPeople = int.Parse(Console.ReadLine());

          
            double moneyForTickets = 0.0;

            if (numberOfPeople >= 1 && numberOfPeople <= 4)
            {
                budget = budget * 0.25;
            }

            else if (numberOfPeople > 4 && numberOfPeople <= 9)
            {
                budget = budget * 0.40;
            }

            else if (numberOfPeople > 9 && numberOfPeople <= 24)
            {
                budget = budget * 0.50;
            }

            else if (numberOfPeople > 24 && numberOfPeople <= 49)
            {
                budget = budget * 0.60;
            }

            else
            {
                budget = budget * 0.75;
            }

           

            if (category == "VIP")
            {
                moneyForTickets = numberOfPeople * 499.99;
            }

            else
            {
                moneyForTickets = numberOfPeople * 249.99;
            }

            if (moneyForTickets > budget)
            {
                Console.WriteLine($"Not enough money! You need {moneyForTickets - budget:F2} leva.");
            }

            else 
            {
                Console.WriteLine($"Yes! You have {budget - moneyForTickets:f2} leva left.");
            }
            
        }
    }
}
 