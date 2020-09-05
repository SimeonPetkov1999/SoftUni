using System;

namespace _06TruckDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmForMouth = double.Parse(Console.ReadLine());

            double moneyForKm = 0.0;
            double finalMoney = 0.0;

            if (kmForMouth<=5000)
            {
                if (season=="Spring" || season =="Autumn")
                {
                    moneyForKm = 0.75;
                }

                else if (season =="Summer")
                {
                    moneyForKm = 0.90;
                }

                else
                {
                    moneyForKm = 1.05;
                }
            }

            else if (kmForMouth > 5000 && kmForMouth<=10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    moneyForKm = 0.95;
                }

                else if (season == "Summer")
                {
                    moneyForKm = 1.10;
                }

                else
                {
                    moneyForKm = 1.25;
                }
            }

            else
            {
                moneyForKm = 1.45;
            }

            finalMoney = ((kmForMouth * moneyForKm) *4) * 0.90;

            Console.WriteLine($"{finalMoney:f2}");
        }
    }
}
