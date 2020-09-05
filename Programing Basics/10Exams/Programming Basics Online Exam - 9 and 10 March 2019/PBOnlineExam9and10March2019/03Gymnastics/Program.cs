using System;
using System.Transactions;

namespace _03Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string ured = Console.ReadLine();

            double ocenkaTrudnost = 0.0;
            double ocenkaIzpulnenie = 0.0;

            switch (ured)
            {
                case "ribbon":
                    switch (country)
                    {
                        case "Russia":
                            ocenkaTrudnost = 9.100;
                            ocenkaIzpulnenie = 9.400;
                            break;
                        case "Bulgaria":
                            ocenkaTrudnost = 9.600;
                            ocenkaIzpulnenie = 9.400;
                            break;
                        case "Italy":
                            ocenkaTrudnost = 9.200;
                            ocenkaIzpulnenie = 9.500;
                            break;
                    }
                    break;
                case "hoop":
                    switch (country)
                    {
                        case "Russia":
                            ocenkaTrudnost = 9.300;
                            ocenkaIzpulnenie = 9.800;
                            break;
                        case "Bulgaria":
                            ocenkaTrudnost = 9.550;
                            ocenkaIzpulnenie = 9.750;
                            break;
                        case "Italy":
                            ocenkaTrudnost = 9.450;
                            ocenkaIzpulnenie = 9.350;
                            break;
                    }
                    break;
                case "rope":
                    switch (country)
                    {
                        case "Russia":
                            ocenkaTrudnost = 9.600;
                            ocenkaIzpulnenie = 9.000;
                            break;
                        case "Bulgaria":
                            ocenkaTrudnost = 9.500;
                            ocenkaIzpulnenie = 9.400;
                            break;
                        case "Italy":
                            ocenkaTrudnost = 9.700;
                            ocenkaIzpulnenie = 9.150;
                            break;
                    }
                    break;

                    
            }
            double finalresult = ocenkaIzpulnenie + ocenkaTrudnost;
            double diff = 20 - finalresult;
            double percentage = (diff / 20) * 100;

            Console.WriteLine($"The team of {country} get {finalresult:f3} on {ured}.");
            Console.WriteLine($"{percentage:f2}%");

        }
    }
}
