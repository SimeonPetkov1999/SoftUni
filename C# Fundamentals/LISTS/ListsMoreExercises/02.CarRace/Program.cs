using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            double firstRacerTime = 0;
            double secondRacerTime = 0;

            for (int i = 0; i < numbers.Count/2; i++)
            {
                if (numbers[i]==0)
                {
                    firstRacerTime *= 0.8;
                }
                else
                {
                    firstRacerTime += numbers[i];
                }
            }

            for (int i = numbers.Count-1; i > numbers.Count/2; i--)
            {
                if (numbers[i] == 0)
                {
                     secondRacerTime *= 0.8;
                }
                else
                {
                    secondRacerTime += numbers[i];
                }
            }

            if (firstRacerTime<secondRacerTime)
            {
                Console.WriteLine($"The winner is left with total time: {firstRacerTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {secondRacerTime}");

            }
        }
    }
}
