using System;

namespace _11CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int lilyAge = int.Parse(Console.ReadLine());
            double priceForWashingMachine = double.Parse(Console.ReadLine());
            double priceForToys = double.Parse(Console.ReadLine());

            double moneySum = 0.0;
            double money = 10.0;
            int moneyBr = 0;
            int toys = 0;

            

            for (int i = 1; i <=lilyAge ; i++)
            {
                if (i%2 !=0)
                {
                    toys++;
                }
                else
                {
                    moneySum += money;
                    money += 10;
                    moneyBr++;
                }
            }

            moneySum += (toys * priceForToys) - (moneyBr*1);

            if (moneySum>=priceForWashingMachine)
            {
                Console.WriteLine($"Yes! {moneySum-priceForWashingMachine:f2}");
            }

            else
            {
                Console.WriteLine($"No! {priceForWashingMachine-moneySum:f2}");
            }
        }
    }
}
