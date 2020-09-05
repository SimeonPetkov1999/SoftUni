using System;

namespace DepositCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double DepositedAmount = double.Parse(Console.ReadLine());
            int Srok = int.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine()) / 100;
           

            double sum = DepositedAmount + Srok * ((DepositedAmount * interest) / 12);
            Console.WriteLine(sum);
        }
    }
}
