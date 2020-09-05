using System;

namespace _02TravelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTickets = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            int priceForTiket = int.Parse(Console.ReadLine());

            int neededMoney = priceForTiket * numberOfTickets;

            if (neededMoney>budget)
            {
                Console.WriteLine($"The budget of {budget}$ is not enough. Your client can't buy {numberOfTickets} tickets with this budget!");
            }

            else
            {
                Console.WriteLine($"You can sell your client {numberOfTickets} tickets for the price of {neededMoney}$!");
                Console.WriteLine($"Your client should become a change of {budget-neededMoney}$!");
            }
        }
    }
}
