using _04.BorderControl.Interfaces;
using _04.BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<IInhabitant>();
            while (true)
            {
                var commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0]=="End")
                {
                    break;
                }
                var name = commandArgs[0];
                if (commandArgs.Length==3)
                {                
                    var citizenAge = int.Parse(commandArgs[1]);
                    var citizenID = commandArgs[2];
                    var citizen = new Cititzen(name, citizenAge, citizenID);
                    list.Add(citizen);
                }
                else
                {
                    var robotID = commandArgs[1];
                    var robor = new Robot(name, robotID);
                    list.Add(robor);
                }
            }

            var lastDigits = Console.ReadLine();

            list = list.Where(x => x.ID.EndsWith(lastDigits)).ToList();
            list.ForEach(x => Console.WriteLine(x.ID));
        }
    }
}
