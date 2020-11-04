using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cars = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0]=="register")
                {
                    string username = command[1];
                    string plate = command[2];

                    if (!cars.ContainsKey(username))
                    {
                        cars.Add(username, plate);
                        Console.WriteLine($"{username} registered {plate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {plate}");
                    }
                }

                else if (command[0]=="unregister")
                {
                    string username = command[1];

                    if (!cars.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        cars.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
