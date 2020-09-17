using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double allMoney = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double lightSabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            double finalPriceSabers = lightSabersPrice * (Math.Ceiling(numberOfStudents * 1.10));
            double finalPriceRobes = robesPrice * numberOfStudents;

            double freeBelts = numberOfStudents / 6; ;

            double finalPriceBelts = beltsPrice * (numberOfStudents - freeBelts);

            double totalPrice = finalPriceSabers + finalPriceRobes + finalPriceBelts;

            if (allMoney >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalPrice - allMoney:f2}lv more.");
            }
        }
    }
}
