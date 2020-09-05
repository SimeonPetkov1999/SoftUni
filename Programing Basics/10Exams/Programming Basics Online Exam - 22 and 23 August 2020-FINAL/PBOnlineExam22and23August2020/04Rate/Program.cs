using System;

namespace _04Rate
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int numberOfMonths = int.Parse(Console.ReadLine());

            double simpleIterest = money;
            double complexInterest = money;

            for (int i = 1; i <= numberOfMonths; i++)
            {
                simpleIterest = simpleIterest + (money * 0.03);
                complexInterest *= 1.027;
            }
            Console.WriteLine($"Simple interest rate: {simpleIterest:f2} lv.");
            Console.WriteLine($"Complex interest rate: {complexInterest:f2} lv.");
            if (simpleIterest<complexInterest)
            {
                Console.WriteLine($"Choose a complex interest rate. You will win {complexInterest-simpleIterest:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Choose a simple interest rate. You will win {simpleIterest-complexInterest:f2} lv.");
            }
        }
    }
}
