using System;

namespace _06DailyWage
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfPosition = int.Parse(Console.ReadLine());
            double strawberries = 0;
            double berries = 0;

            for (int rows = 1; rows <= numberOfRows; rows++)
            {

                for (int position = 1; position <= numberOfPosition; position++)
                {

                    if (rows % 2 != 0)
                    {
                        strawberries += 3.50;
                    }

                    if (rows % 2 == 0 && (position % 3 != 0))
                    {
                        berries += 5.00;
                    }

                }

            }

            double finalPrice = strawberries + berries;
            finalPrice *= 0.80;
            Console.WriteLine($"Total: {finalPrice:f2} lv.");

        }
    }
}
