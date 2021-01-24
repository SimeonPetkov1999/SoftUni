using _05.BirthdayCelebrations.Interfaces;
using _05.BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<IBirthable>();
            while (true)
            {
                var commandArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0] == "End")
                {
                    break;
                }
                var type = commandArgs[0];
                if (type == "Citizen")
                {
                    list.Add(CreateCitizen(commandArgs));
                }
                else if (type == "Pet")
                {
                    list.Add(CreatePet(commandArgs));
                }
            }
            var year = Console.ReadLine();

            list = list.Where(x => x.BirthYear == year).ToList();
            list.ForEach(x => Console.WriteLine(x.BirthDate));
        }

        private static Pet CreatePet(string[] commandArgs)
        {
            var petName = commandArgs[1];
            var petBirthDate = commandArgs[2];
            var pet = new Pet(petName, petBirthDate);
            return pet;
        }

        private static Cititzen CreateCitizen(string[] commandArgs)
        {
            var citizenName = commandArgs[1];
            var citizenAge = int.Parse(commandArgs[2]);
            var citizenID = commandArgs[3];
            var citizenBirthDate = commandArgs[4];
            var citizen = new Cititzen(citizenName, citizenAge, citizenID, citizenBirthDate);
            return citizen;
        }
    }
}
