using System;

namespace _08CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int ticketPrice;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    ticketPrice = 12;
                    break;
                case "Wednesday":
                case "Thursday":
                    ticketPrice = 14;
                    break;
                default:
                    ticketPrice = 16;
                    break;
            }

            Console.WriteLine(ticketPrice);
        }
    }
}
