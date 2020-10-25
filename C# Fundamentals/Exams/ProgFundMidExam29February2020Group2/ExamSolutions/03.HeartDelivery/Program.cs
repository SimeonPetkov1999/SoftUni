using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine().Split();

            int cupidIndex = 0;


            while (command[0] != "Love!")
            {
                int lenght = int.Parse(command[1]);

                cupidIndex += lenght;
                if (cupidIndex >= neighborhood.Count)
                {
                    cupidIndex = 0;
                }

                if (neighborhood[cupidIndex] == 0)
                {
                    Console.WriteLine($"Place {cupidIndex} already had Valentine's day.");
                }
                else
                {
                    neighborhood[cupidIndex] -= 2;
                    if (neighborhood[cupidIndex] == 0)
                    {
                        Console.WriteLine($"Place {cupidIndex} has Valentine's day.");
                    }
                }
                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"Cupid's last position was {cupidIndex}.");

            if (neighborhood.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int fails = 0;
                foreach (var item in neighborhood)
                {
                    if (item!=0)
                    {
                        fails++;
                    }
                }
                Console.WriteLine($"Cupid has failed {fails} places.");
            }
        }
    }
}
