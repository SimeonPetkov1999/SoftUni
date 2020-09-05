using System;

namespace _05Travelling
{
    class Program
    {
        static void Main(string[] args)
        {

            double allMoney = 0;

            while (true)
            {
                string destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
                double neededMoney = double.Parse(Console.ReadLine());

                while (neededMoney > allMoney)
                {
                    double money = double.Parse(Console.ReadLine());
                    allMoney += money;
                }
                allMoney = 0;
                Console.WriteLine($"Going to {destination}!");

            }
        }
    }
}
