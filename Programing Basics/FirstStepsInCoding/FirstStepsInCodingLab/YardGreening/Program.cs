using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double Meters = double.Parse(Console.ReadLine());

            double Price = Meters * 7.61;
            double discount = Price * 0.18;
            double finalPrice = Price - discount;


            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");

        }
    }
}
