using System;

namespace _04GameNumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayer = Console.ReadLine();
            string secondPlayer = Console.ReadLine();
            int pointsFirstPlayer = 0;
            int pointsSecondPlayer = 0;
            int num1 = 0;
            int num2 = 0;

            while (true)
            {
                string p1 = Console.ReadLine();
                if (p1 == "End of game")
                {
                    Console.WriteLine($"{firstPlayer} has {pointsFirstPlayer} points");
                    Console.WriteLine($"{secondPlayer} has {pointsSecondPlayer} points");
                    break;
                }
                string p2 = Console.ReadLine();
                if (p1 == p2)
                {
                    Console.WriteLine("Number wars!");
                    int one = int.Parse(Console.ReadLine());
                    int two = int.Parse(Console.ReadLine());

                    if (one > two)
                    {
                        Console.WriteLine($"{firstPlayer} is winner with {pointsFirstPlayer} points");
                    }

                    else if (one < two)
                    {
                        Console.WriteLine($"{secondPlayer} is winner with {pointsSecondPlayer} points");
                    }

                    break;
                }
                num1 = int.Parse(p1);
                num2 = int.Parse(p2);
                if (num1 > num2)
                {
                    pointsFirstPlayer += num1 - num2;
                }
                else if (num1 < num2)
                {
                    pointsSecondPlayer += num2 - num1;
                }
            }
        }
    }
}
