using System;

namespace _04TransportPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            double price = 0.0;

            if (km < 20)
            {
                if (timeOfDay == "day")
                {
                    price = 0.70 + (0.79 * km);
                }
                else
                {
                    price = 0.70 + (0.90 * km);
                }

                Console.WriteLine($"{price:f2}");
            }

            else if (km>=20 && km <100)
            {
                price = km * 0.09;
                Console.WriteLine($"{price:f2}");
            }

            else
            {
                price = km * 0.06;
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
