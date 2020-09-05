using System;

namespace _04TreekingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfHikers = int.Parse(Console.ReadLine());
            int allHickers = 0;
            int hickers = 0;

            double HickersForMusala = 0.0;
            double HickersForMonblan = 0.0;
            double HickersForKilimandjaro = 0.0;
            double HickersForK2 = 0.0;
            double HickersForEverest = 0.0;


            for (int i = 1; i <= numberOfHikers; i++)
            {
                hickers = int.Parse(Console.ReadLine());
                allHickers = allHickers + hickers;

                if (hickers <= 5)
                {
                    HickersForMusala = HickersForMusala + hickers;
                }

                else if (hickers >= 6 && hickers <= 12)
                {
                    HickersForMonblan = HickersForMonblan + hickers;
                }

                else if (hickers >= 13 && hickers <= 25)
                {
                    HickersForKilimandjaro = HickersForKilimandjaro + hickers;
                }

                else if (hickers >= 26 && hickers <= 40)
                {
                    HickersForK2 = HickersForK2 + hickers;
                }

                else if (hickers >= 41)
                {
                    HickersForEverest = HickersForEverest + hickers;
                }

                hickers = 0;
            }

            double perecentageMusala = (HickersForMusala / allHickers) * 100;
            double perecentageMonblan = (HickersForMonblan / allHickers) * 100;
            double perecentageKilimandjaro = (HickersForKilimandjaro / allHickers) * 100;
            double perecentageK2 = (HickersForK2 / allHickers) * 100;
            double perecentageEverest = (HickersForEverest / allHickers) * 100;

            Console.WriteLine($"{perecentageMusala:f2}%");
            Console.WriteLine($"{perecentageMonblan:f2}%");
            Console.WriteLine($"{perecentageKilimandjaro:f2}%");
            Console.WriteLine($"{perecentageK2:f2}%");
            Console.WriteLine($"{perecentageEverest:f2}%");

        }
    }
}
