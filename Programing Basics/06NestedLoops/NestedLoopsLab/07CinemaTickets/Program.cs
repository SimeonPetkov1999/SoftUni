using System;
using System.Runtime.InteropServices;

namespace _07CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int currStudent = 0;
            int currStandard = 0;
            int currKid = 0;
            int allCurrTickets = 0;

            int allStudent = 0;
            int allStandard = 0;
            int allKid = 0;
            int allTickets = 0;
            while (true)
            {
                string nameOfMovie = Console.ReadLine();
                if (nameOfMovie == "Finish")
                {
                    double percentageAllStudent = allStudent * 1.0 / allTickets * 100;
                    double percentageAllStandard = allStandard * 1.0 / allTickets * 100;
                    double percentageAllKid = allKid * 1.0 / allTickets * 100;
                    Console.WriteLine($"Total tickets: {allTickets}");
                    Console.WriteLine($"{percentageAllStudent:f2}% student tickets.");
                    Console.WriteLine($"{percentageAllStandard:f2}% standard tickets.");
                    Console.WriteLine($"{percentageAllKid:f2}% kids tickets.");
                    break;                    
                }
                int numberOfSeats = int.Parse(Console.ReadLine());

                string ticketType = Console.ReadLine();
                while (numberOfSeats > allCurrTickets)
                {
                    if (ticketType == "End")
                    {
                        break;
                    }
                    switch (ticketType)
                    {
                        case "student":
                            currStudent++;
                            allCurrTickets++;
                            break;
                        case "standard":
                            currStandard++;
                            allCurrTickets++;
                            break;
                        case "kid":
                            currKid++;
                            allCurrTickets++;
                            break;
                    }
                    if (allCurrTickets >= numberOfSeats)
                    {
                        break;
                    }
                    ticketType = Console.ReadLine();
                }

                allTickets += allCurrTickets;
                allStudent += currStudent;
                allStandard += currStandard;
                allKid += currKid;
                double percentageCurrFull = allCurrTickets * 1.0 / numberOfSeats * 100;
                allCurrTickets = 0;
                currKid = 0;
                currStandard = 0;
                currStudent = 0;
                Console.WriteLine($"{nameOfMovie} - {percentageCurrFull:f2}% full.");

            }
        }
    }
}
