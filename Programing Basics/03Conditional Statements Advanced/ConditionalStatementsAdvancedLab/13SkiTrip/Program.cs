using System;

namespace _13SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOFRoom = Console.ReadLine();
            string ocenka = Console.ReadLine();

            double price = 0.0;
            double finalPrice = 0.0;

            switch (typeOFRoom)
            {
                case "room for one person":
                    price = 18.00;
                    finalPrice = price * (days - 1);
                    break;
                case "apartment":
                    price = 25.00;
                    finalPrice = price * (days - 1);
                    if (days<10)
                    {
                        finalPrice *= 0.70;
                    }
                    else if (days>=10 && days <=15)
                    {
                        finalPrice *= 0.65;
                    }
                    else if(days >15)
                    {
                        finalPrice *= 0.50;
                    }
                    break;

                case "president apartment":
                    price = 35.00;
                    finalPrice = price * (days - 1);
                    if (days < 10)
                    {
                        finalPrice *= 0.90;
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        finalPrice *= 0.85;
                    }
                    else if (days > 15)
                    {
                        finalPrice *= 0.80;
                    }
                    break;
            }

            if (ocenka =="positive")
            {
                finalPrice *= 1.25;
                Console.WriteLine($"{finalPrice:f2}");
            }

            else
            {
                finalPrice *= 0.90;
                Console.WriteLine($"{finalPrice:f2}");
            }
        }
    }
}
