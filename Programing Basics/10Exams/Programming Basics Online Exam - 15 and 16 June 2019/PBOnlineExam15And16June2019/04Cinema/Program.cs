using System;

namespace _04Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityOfCinema = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int allPeople = 0;
            int money = 0;

            while (input != "Movie time!")
            {
                int currentPeople = int.Parse(input);
                allPeople += currentPeople;
                if (allPeople > capacityOfCinema)
                {
                    Console.WriteLine("The cinema is full.");
                    Console.WriteLine($"Cinema income - {money} lv.");
                    Environment.Exit(0);
                }

                if (currentPeople % 3 != 0)
                {
                    money = money + (currentPeople * 5);
                }
                else
                {
                    money = (money + (currentPeople * 5))-5;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"There are {capacityOfCinema-allPeople} seats left in the cinema.");
            Console.WriteLine($"Cinema income - {money} lv.");
        }
    }
}
