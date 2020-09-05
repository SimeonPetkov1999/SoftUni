using System;

namespace _01MovieProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfMovie = Console.ReadLine();
            int numberOfDays = int.Parse(Console.ReadLine());
            int numberOfTickets = int.Parse(Console.ReadLine());
            double priceForOneTicket = double.Parse(Console.ReadLine());
            int percentageForCinema = int.Parse(Console.ReadLine());

            double priceForTickets = numberOfTickets * priceForOneTicket;
            double incomeForThePeriod = numberOfDays * priceForTickets;
            double moneyForCinema = incomeForThePeriod * percentageForCinema / 100;
            double finalIncome = incomeForThePeriod - moneyForCinema;

            Console.WriteLine($"The profit from the movie {nameOfMovie} is {finalIncome:f2} lv.");
        }
    }
}
