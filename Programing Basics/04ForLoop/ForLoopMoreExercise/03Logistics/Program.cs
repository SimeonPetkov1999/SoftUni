using System;

namespace _03Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCargo = int.Parse(Console.ReadLine());

            double money = 0.0;
            int allTons = 0;
            double tonsForBus = 0.0;
            double tonsForTruck = 0.0;
            double tonsForTrain = 0.0;


            for (int i = 0; i < numberOfCargo; i++)
            {
                int tonsOfCargo = int.Parse(Console.ReadLine());

                if (tonsOfCargo <= 3)
                {
                    tonsForBus += tonsOfCargo;
                }
                else if (tonsOfCargo >= 4 && tonsOfCargo <= 11)
                {
                    tonsForTruck += tonsOfCargo;
                }
                else if (tonsOfCargo >= 12)
                {
                    tonsForTrain += tonsOfCargo;
                }
                allTons += tonsOfCargo;
            }

            money = ((tonsForBus * 200) + (tonsForTruck * 175) + (tonsForTrain * 120)) / allTons;

            double percentageWithBus = (tonsForBus / allTons) * 100;
            double percentageWtihTruck = (tonsForTruck / allTons) * 100;
            double percentageWithTrain = (tonsForTrain / allTons) * 100;

            Console.WriteLine($"{money:f2}");
            Console.WriteLine($"{percentageWithBus:f2}%");
            Console.WriteLine($"{percentageWtihTruck:f2}%");
            Console.WriteLine($"{percentageWithTrain:f2}%");

        }
    }
}
