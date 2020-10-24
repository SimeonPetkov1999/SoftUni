using System;
using System.Linq;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int health = 100;
            int finalBitcoins = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currentRoom = rooms[i].Split();

                if (currentRoom[0]=="potion")
                {
                    int amount = int.Parse(currentRoom[1]);                  
                    if (amount+health>100)
                    {
                        Console.WriteLine($"You healed for {100-health} hp.");
                        health = 100;
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {amount} hp.");
                        health += amount;
                    }

                    Console.WriteLine($"Current health: {health} hp.");
                }

                else if (currentRoom[0]=="chest")
                {
                    int bitcoinsInRoom = int.Parse(currentRoom[1]);
                    Console.WriteLine($"You found {bitcoinsInRoom} bitcoins.");
                    finalBitcoins += bitcoinsInRoom;
                }

                else
                {
                    string monster = currentRoom[0];
                    int power = int.Parse(currentRoom[1]);
                    health -= power;
                    if (health>0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }

                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i+1}");
                        Environment.Exit(0);
                    }
                }

            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {finalBitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
