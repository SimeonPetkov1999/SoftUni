using System;

namespace _08FuelTankPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double litersFuel = double.Parse(Console.ReadLine());
            string discountCard = Console.ReadLine();
            double price = 0.0;

            if (fuelType == "Gasoline")
            {

                if (discountCard == "Yes")
                {
                    price = litersFuel * (2.22 - 0.18);
                }

                else
                {
                    price = litersFuel * 2.22;
                }

                if (litersFuel >= 20 && litersFuel <= 25)
                {
                    price = price * 0.92;
                }

                else if (litersFuel > 25)
                {
                    price = price * 0.90;
                }

                Console.WriteLine($"{price:f2} lv.");
            }

            else if (fuelType == "Diesel")
            {

                if (discountCard == "Yes")
                {
                    price = litersFuel * (2.33 - 0.12);
                }

                else
                {
                    price = litersFuel * 2.33;
                }

                if (litersFuel >= 20 && litersFuel <= 25)
                {
                    price = price * 0.92;
                }

                else if (litersFuel > 25)
                {
                    price = price * 0.90;
                }

                Console.WriteLine($"{price:f2} lv.");
            }

            else
            {

                if (discountCard == "Yes")
                {
                    price = 0.93 - 0.08;
                    price = litersFuel * price;
                }

                else
                {
                    price = litersFuel * 0.93;
                }

                if (litersFuel >= 20 && litersFuel <= 25)
                {
                    price = price * 0.92;
                }

                else if (litersFuel > 25)
                {
                    price = price * 0.90;
                }

                Console.WriteLine($"{price:f2} lv.");
            }
        }
    }
}
