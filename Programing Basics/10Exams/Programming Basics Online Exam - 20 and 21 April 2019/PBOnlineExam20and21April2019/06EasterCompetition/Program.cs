using System;

namespace _06EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBreads = int.Parse(Console.ReadLine());
            int point;
            int maxPoints = -100, currenPoints = 0 ;
            string input;
            string nameOfCooker, nameOfWinner="";

            for (int i = 0; i < numberOfBreads; i++)
            {
                nameOfCooker = Console.ReadLine();
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == "Stop")
                    {
                        break;
                    }

                    point = int.Parse(input);


                    currenPoints += point;
                    
                }

                if (currenPoints>maxPoints)
                {
                    maxPoints = currenPoints;
                    nameOfWinner = nameOfCooker;

                    Console.WriteLine($"{nameOfCooker} has {currenPoints} points.");
                    Console.WriteLine($"{nameOfWinner} is the new number 1!");
                }

                else
                {
                    Console.WriteLine($"{nameOfCooker} has {currenPoints} points.");
                }

                currenPoints = 0;
            }

            Console.WriteLine($"{nameOfWinner} won competition with {maxPoints} points!");
        }
    }
}
