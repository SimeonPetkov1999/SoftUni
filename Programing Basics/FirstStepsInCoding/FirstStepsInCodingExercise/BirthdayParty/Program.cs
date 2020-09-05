using System;

namespace BirthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double Rent = double.Parse(Console.ReadLine());

            double Cake = Rent * 0.20;
            double Drinks = Cake - (Cake * 0.45);
            double Animator = Rent / 3;

            double finalSum = Rent+Cake + Drinks + Animator;
            Console.WriteLine(finalSum);
        }
    }
}
