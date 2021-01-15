using System;

namespace _4.HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split();

            var pricePerDay = decimal.Parse(input[0]);
            var numberOfDays = int.Parse(input[1]);
            var season = Enum.Parse<Season>(input[2]);
            var discount = Discount.None;
            if (input.Length == 4)
            {
                discount = Enum.Parse<Discount>(input[3]);
            }
            var total = PriceCalculator.GetTotalPrice(pricePerDay, numberOfDays, season, discount);
            Console.WriteLine($"{total:f2}");

        }
    }
}
