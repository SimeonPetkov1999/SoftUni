using System;

namespace _09Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfyear = Console.ReadLine();
            int PholidaysInYear = int.Parse(Console.ReadLine());
            int HweekendsHomeTown = int.Parse(Console.ReadLine());

            double weekendsInSofia = 48 - HweekendsHomeTown;
            double gamesInSofia = (3.0 / 4.0) * weekendsInSofia;

            double gamesInSofiaDuringHoliday = PholidaysInYear * (2.0 / 3.0);

            double allGames = gamesInSofia + HweekendsHomeTown + gamesInSofiaDuringHoliday;

            if (typeOfyear == "leap")
            {
                allGames *= 1.15;
            }

            allGames = Math.Floor(allGames);

            Console.WriteLine(allGames);
        }
    }
}
