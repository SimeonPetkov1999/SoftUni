using System;

namespace _03EasterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());
            double priceForNight = 0.0;
            double finalPrice = 0.0;

            switch (destination)
            {
                case "France":
                    if (dates=="21-23")
                    {
                        priceForNight = 30;
                    }

                    else if (dates=="24-27")
                    {
                        priceForNight = 35;
                    }

                    else
                    {
                        priceForNight = 40;
                    }
                    break;

                case "Italy":
                    if (dates == "21-23")
                    {
                        priceForNight = 28;
                    }

                    else if (dates == "24-27")
                    {
                        priceForNight = 32;
                    }

                    else
                    {
                        priceForNight = 39;
                    }
                    break;

                default:
                    if (dates == "21-23")
                    {
                        priceForNight = 32;
                    }

                    else if (dates == "24-27")
                    {
                        priceForNight = 37;
                    }

                    else
                    {
                        priceForNight = 43;
                    }
                    break;
            }

            finalPrice = priceForNight * numberOfNights;

            Console.WriteLine($"Easter trip to {destination} : {finalPrice:f2} leva.");
        }
    }
}
