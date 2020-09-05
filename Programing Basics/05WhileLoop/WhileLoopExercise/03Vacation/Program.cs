using System;

namespace _03Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoneyForVacation = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());
            int days = 0;
            int check = 0;

            while (true)
            {
                string input = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                days++;
                if (input=="save")
                {
                    check = 0;
                    ownedMoney += money;
                    if (ownedMoney>=neededMoneyForVacation)
                    {
                        Console.WriteLine($"You saved the money for {days} days.");
                        break;
                    }
                }
                else if (input=="spend")
                {
                    check++;
                    if (money>ownedMoney)
                    {
                        ownedMoney = 0;
                        continue;
                    }

                    ownedMoney = ownedMoney - money;
                }

                if (check==5)
                {
                    Console.WriteLine($"You can't save the money.");
                    Console.WriteLine(days);
                    break;
                }
            }

        }
    }
}
