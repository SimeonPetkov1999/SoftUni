﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input!="end")
            {
                List<string> command = input.Split().ToList();

                if (command[0]=="Add")
                {
                    wagons.Add(int.Parse(command[1]));
                }

                else
                {
                    int passengers = int.Parse(command[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <=maxCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }

                input = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ",wagons));
        }
    }
}
