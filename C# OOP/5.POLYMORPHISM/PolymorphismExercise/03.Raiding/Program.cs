using _03.Raiding.Models;
using _03.Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroes = new List<IHero>();

            int n = int.Parse(Console.ReadLine());
            int validHeroes = 0;
            while (validHeroes != n)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();
                IHero curentHero = null;
                try
                {
                    curentHero = CreateHero(heroName, heroType);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    continue;
                }

                validHeroes++;
                heroes.Add(curentHero);
            }

            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int allPower = heroes.Sum(h => h.Power);
            if (allPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static IHero CreateHero(string heroName, string heroType)
        {
            IHero curentHero = null;
            if (heroType == "Druid")
            {
                curentHero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                curentHero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                curentHero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                curentHero = new Warrior(heroName);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero!");
            }

            return curentHero;
        }
    }
}
