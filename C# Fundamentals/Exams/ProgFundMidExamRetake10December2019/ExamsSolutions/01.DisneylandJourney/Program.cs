using System;

namespace _01.DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForJourney = double.Parse(Console.ReadLine());
            int numberOfMonths = int.Parse(Console.ReadLine());
            double monthSave = moneyForJourney * 0.25;

            double moneySaved = 0;
            for (int i = 1; i <= numberOfMonths; i++)
            {
                if (i != 1 && i % 2 != 0)
                {
                    moneySaved -= (moneySaved * 0.16);
                }

                if (i % 4 == 0)
                {
                    moneySaved += (moneySaved * 0.25);
                }
                moneySaved += monthSave;
            }

            if (moneySaved>=moneyForJourney)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {moneySaved-moneyForJourney:f2}lv. for souvenirs.");
            }

            else
            {
                Console.WriteLine($"Sorry. You need {moneyForJourney-moneySaved:f2}lv. more.");
            }

        }
    }
}
