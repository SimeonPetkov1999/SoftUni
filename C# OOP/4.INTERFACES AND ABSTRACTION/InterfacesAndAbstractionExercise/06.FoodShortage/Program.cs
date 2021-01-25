using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs.Length==4)
                { 
                    list.Add(CreateCitizen(commandArgs));
                }
                else
                {
                    list.Add(CreateRebel(commandArgs));
                }
            }

            while (true)
            {
                var command = Console.ReadLine();
                if (command=="End")
                {
                    break;
                }

                if (list.Any(n=>n.Name==command))
                {
                    var curr = list.First(n => n.Name == command);
                    curr.BuyFood();
                }
            }

            //var allfood = 0;
            //foreach (var item in list)
            //{
            //    allfood += item.Food;
            //}

            //Console.WriteLine(allfood);

            Console.WriteLine(list.Sum(n => n.Food));
        }

        private static Rebel CreateRebel(string[] commandArgs)
        {
            var name = commandArgs[0];
            var age = int.Parse(commandArgs[1]);
            var group = commandArgs[2];
            return new Rebel(name, age, group);
        }

        private static Cititzen CreateCitizen(string[] commandArgs)
        {
            var name = commandArgs[0];
            var age = int.Parse(commandArgs[1]);
            var id = commandArgs[2];
            var birthDate = commandArgs[3];

            return new Cititzen(name, age, id, birthDate);
        }
    }
}
