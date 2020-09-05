using System;

namespace _03Aquapark
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();

            double price = 0;

            if (timeOfDay=="day")
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        price = 10.50;
                        break;
                    case "june":
                    case "july":
                    case "august":
                        price = 12.60;
                        break;
                }
            }

            else
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        price = 8.40;
                        break;
                    case "june":
                    case "july":
                    case "august":
                        price = 10.20;
                        break;
                }
            }

            if (people>=4)
            {
                price *= 0.90;
            }
            if (hours>=5)
            {
                price *= 0.50;
            }

            double finalPrice = (people * price) * hours;

            Console.WriteLine($"Price per person for one hour: {price:f2}");
            Console.WriteLine($"Total cost of the visit: {finalPrice:f2}");

        }
    }
}
