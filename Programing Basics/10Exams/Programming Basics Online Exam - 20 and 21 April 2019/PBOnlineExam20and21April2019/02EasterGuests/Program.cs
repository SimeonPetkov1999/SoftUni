using System;

namespace _02EasterGuests
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGuests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double neededBreads = Math.Ceiling(numberOfGuests / 3.0);
            int neededEggs = numberOfGuests * 2;

            double priceForBreads = neededBreads * 4;
            double priceForEggs = neededEggs * 0.45;
            double allPrice = priceForBreads + priceForEggs;

            if (allPrice <= budget)
            {
                Console.WriteLine($"Lyubo bought {neededBreads} Easter bread and {neededEggs} eggs.");
                Console.WriteLine($"He has {budget - allPrice:f2} lv. left.");
            }

            else
            {
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {allPrice - budget:f2} lv. more.");
            }
        }
    }
}
