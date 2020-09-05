using System;

namespace _05Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfSeries = int.Parse(Console.ReadLine());
            double finalPrice = 0.0;

            for (int i = 0; i < numberOfSeries; i++)
            {
                string Series = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                switch (Series)
                {
                    case "Thrones":
                        price = price * 0.50;
                        break;
                    case "Lucifer":
                        price = price * 0.60;
                        break;
                    case "Protector":
                        price = price * 0.70;
                        break;
                    case "TotalDrama":
                        price = price * 0.80;
                        break;
                    case "Area":
                        price = price * 0.90;
                        break;
                }
                finalPrice += price;
            }

            if (budget >= finalPrice)
            {
                Console.WriteLine($"You bought all the series and left with {budget - finalPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {finalPrice - budget:f2} lv. more to buy the series!");
            }
        }
    }
}
