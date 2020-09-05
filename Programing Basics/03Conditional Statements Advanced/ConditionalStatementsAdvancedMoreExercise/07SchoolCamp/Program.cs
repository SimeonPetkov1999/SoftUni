using System;

namespace _07SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string group = Console.ReadLine();
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfNights = int.Parse(Console.ReadLine());

            string sport = "";
            double price = 0.0;
            double finalPrice = 0.0;

            switch (group)
            {
                case "girls":
                    if (season=="Winter")
                    {
                        sport = "Gymnastics";
                        price = 9.60;
                    }

                    else if (season=="Spring")
                    {
                        sport = "Athletics";
                        price = 7.20;
                    }

                    else
                    {
                        sport = "Voleball";
                        price = 15;
                    }
                    break;

                case "boys":
                    if (season == "Winter")
                    {
                        sport = "Judo";
                        price = 9.60;
                    }

                    else if (season == "Spring")
                    {
                        sport = "Tennis";
                        price = 7.20;
                    }

                    else
                    {
                        sport = "Football";
                        price = 15;
                    }
                    break;

                default:
                    if (season == "Winter")
                    {
                        sport = "Ski";
                        price = 10;
                    }

                    else if (season == "Spring")
                    {
                        sport = "Cycling";
                        price = 9.50;
                    }

                    else
                    {
                        sport = "Swimming";
                        price = 20;
                    }
                    break;
            }

            finalPrice = (price * numberOfNights) * numberOfStudents;

            if (numberOfStudents>=10 && numberOfStudents<20)
            {
                finalPrice *= 0.95;
            }

            else if (numberOfStudents>=20 && numberOfStudents<50)
            {
                finalPrice *= 0.85;
            }

            else if(numberOfStudents>=50)
            {
                finalPrice *= 0.50;
            }

            Console.WriteLine($"{sport} {finalPrice:f2} lv.");

        }
    }
}
