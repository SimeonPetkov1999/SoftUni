using System;

namespace _06GodzilaKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfStatists = int.Parse(Console.ReadLine());
            double priceForClothesForOneStatist = double.Parse(Console.ReadLine());

            double moneyForDecor = budget * 0.10;
            double moneyForClothest = numberOfStatists * priceForClothesForOneStatist;
            if (numberOfStatists > 150)
            {
                moneyForClothest *= 0.90;
            }

            double neededMoney = moneyForClothest + moneyForDecor;

            if (budget >= neededMoney)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {budget - neededMoney:f2} leva left.");
            }

            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {neededMoney - budget:f2} leva more.");

            }



        }
    }
}
