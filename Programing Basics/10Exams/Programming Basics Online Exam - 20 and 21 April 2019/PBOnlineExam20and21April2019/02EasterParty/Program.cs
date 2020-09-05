using System;

namespace _02EasterParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGuests = int.Parse(Console.ReadLine());
            double priceForOneGuest = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double priceForCake = budget * 0.10;
            double finalPrice = 0.0;

            if (numberOfGuests>=10 && numberOfGuests<=15)
            {
                priceForOneGuest *= 0.85;
            }

            else if (numberOfGuests>=15 && numberOfGuests<=20)
            {
                priceForOneGuest *= 0.80;
            }

            else if (numberOfGuests>20)
            {
                priceForOneGuest *= 0.75;
            }

            finalPrice = (numberOfGuests * priceForOneGuest) + priceForCake;

            if (finalPrice <= budget)
            {
                double moneyLeft = budget - finalPrice;
                Console.WriteLine($"It is party time! {moneyLeft:f2} leva left.");
            }
            else
            {
                double moneyNeeded = finalPrice - budget;
                Console.WriteLine($"No party! {moneyNeeded:f2} leva needed.");
            }


        }
    }
}
