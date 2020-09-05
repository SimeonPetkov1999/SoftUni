using System;

namespace _05Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfActor = Console.ReadLine();
            double pointsActor = double.Parse(Console.ReadLine());
            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string nameOfJury = Console.ReadLine();            
                double points = double.Parse(Console.ReadLine());

                int lenght = nameOfJury.Length;

                pointsActor += (lenght * points) / 2;

                if (pointsActor>1250.5)
                {
                    Console.WriteLine($"Congratulations, {nameOfActor} got a nominee for leading role with {pointsActor:f1}!");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine($"Sorry, {nameOfActor} you need {1250.5-pointsActor:f1} more!");
        }
    }
}
