using System;

namespace _03NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlower = Console.ReadLine();
            int numberOfFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double finalPrice = 0.0;

            switch (typeFlower)
            {
                case "Roses":
                    finalPrice = numberOfFlowers * 5;
                    if (numberOfFlowers>80)
                    {
                        finalPrice *= 0.90;
                    }
                    break;
                case "Dahlias":
                    finalPrice = numberOfFlowers * 3.80;
                    if (numberOfFlowers > 90)
                    {
                        finalPrice *= 0.85;
                    }
                    break;
                case "Tulips":
                    finalPrice = numberOfFlowers * 2.80;
                    if (numberOfFlowers > 80)
                    {
                        finalPrice *= 0.85;
                    }
                    break;
                case "Narcissus":
                    finalPrice = numberOfFlowers * 3;
                    if (numberOfFlowers < 120)
                    {
                        finalPrice *= 1.15;
                    }
                    break;
                case "Gladiolus":
                    finalPrice = numberOfFlowers * 2.50;
                    if (numberOfFlowers < 80)
                    {
                        finalPrice *= 1.20;
                    }
                    break;
            }

            if (finalPrice<=budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberOfFlowers} {typeFlower} and {budget-finalPrice:f2} leva left.");
            }

            else
            {
                Console.WriteLine($"Not enough money, you need {finalPrice-budget:f2} leva more.");
            }
        }
    }
}
