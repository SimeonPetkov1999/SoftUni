using System;

namespace _07HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string mounth = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());
            double studioPrice = 0.0;
            double apartmentPrice = 0.0;

            switch (mounth)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    apartmentPrice = 65;
                    break;
                case "June":
                case "September":
                    studioPrice = 75.20;
                    apartmentPrice = 68.70;
                    break;
                case "July":
                case "August":
                    studioPrice = 76;
                    apartmentPrice = 77;
                    break;
            }

            if (numberOfNights > 7 && numberOfNights < 14 && (mounth == "May" || mounth == "October"))
            {
                studioPrice *= 0.95;
            }
            else if (numberOfNights > 14 && (mounth == "May" || mounth == "October"))
            {
                studioPrice *= 0.70;
            }
            else if (numberOfNights > 14 && (mounth == "June" || mounth == "September"))
            {
                studioPrice *= 0.80;
            }

             if (numberOfNights > 14)
            {
                apartmentPrice *= 0.90;
            }

            Console.WriteLine($"Apartment: {apartmentPrice * numberOfNights:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice * numberOfNights:f2} lv.");


         }
    }
}
