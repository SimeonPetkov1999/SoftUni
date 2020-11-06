using System;

namespace _01.SpringVacationTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int numberOfpeople = int.Parse(Console.ReadLine());
            double priceForFuelFor1Km = double.Parse(Console.ReadLine());
            double foodExpensesPerDay1Person = double.Parse(Console.ReadLine());
            double priceForRoomFor1Person = double.Parse(Console.ReadLine());

            double foodExpenses = foodExpensesPerDay1Person * numberOfpeople * days;
            double priceForHotel = priceForRoomFor1Person * numberOfpeople * days;
            if (numberOfpeople>10)
            {
                priceForHotel *= 0.75;
            }

            double totalExpenses = foodExpenses + priceForHotel;

            for (int i = 1; i <= days; i++)
            {
                double travelledDistance = double.Parse(Console.ReadLine());
                totalExpenses += travelledDistance * priceForFuelFor1Km;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    totalExpenses = totalExpenses + (totalExpenses * 0.4);
                }

                if (i % 7 == 0)
                {
                    totalExpenses = totalExpenses - (totalExpenses / numberOfpeople);
                }

                if (totalExpenses>budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {totalExpenses-budget:f2}$ more.");
                     Environment.Exit(0);
                }
            }

            Console.WriteLine($"You have reached the destination. You have {budget-totalExpenses:f2}$ budget left.");
        }
    }
}
