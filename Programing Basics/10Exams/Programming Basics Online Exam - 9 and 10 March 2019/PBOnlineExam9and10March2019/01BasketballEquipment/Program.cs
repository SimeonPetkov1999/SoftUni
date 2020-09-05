using System;

namespace _01BasketballEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int taxForBasketball = int.Parse(Console.ReadLine());

            double basketballShoes = taxForBasketball * 0.60;
            double basketballEquip = basketballShoes * 0.80;
            double basketballBall = basketballEquip / 4;
            double accesories = basketballBall / 5;

            double totalPrice = basketballShoes + basketballEquip + basketballBall + accesories + taxForBasketball;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
