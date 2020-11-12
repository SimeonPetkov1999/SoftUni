using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Stats> heroes = new Dictionary<string, Stats>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string heroName = input[0];
                int HP = int.Parse(input[1]);
                int MP = int.Parse(input[2]);

                if (!heroes.ContainsKey(heroName))
                {
                    heroes[heroName] = new Stats(HP,MP);
                }
            }

            string[] command = Console.ReadLine().Split(" - ");
            while (command[0] != "End")
            {
                string action = command[0];
                if (action == "CastSpell")
                {
                    CastSpell(command, heroes);
                }

                else if (action == "TakeDamage")
                {
                    TakeDamage(command, heroes);
                }
                else if (action == "Recharge")
                {
                    Recharge(command, heroes);
                }

                else if (action == "Heal")
                {
                    Heal(command,heroes);
                }
                command = Console.ReadLine().Split(" - ");
            }

            foreach (var kvp in heroes.OrderByDescending(n => n.Value.HP).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{kvp.Key}");
                Console.WriteLine($"  HP: {kvp.Value.HP}");
                Console.WriteLine($"  MP: {kvp.Value.MP}");
            }
        }

        class Stats
        {
            public Stats(int HP, int MP)
            {
                this.HP = HP;
                this.MP = MP;
            }
            public int HP { get; set; }
            public int MP { get; set; }
        }

        static void CastSpell(string[] command, Dictionary<string, Stats> heroes) 
        {
            string heroName = command[1];
            int MPneeded = int.Parse(command[2]);
            string spellName = command[3];

            if (heroes[heroName].MP >= MPneeded)
            {
                heroes[heroName].MP -= MPneeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }

        static void TakeDamage(string[] command, Dictionary<string, Stats> heroes) 
        {
            string heroName = command[1];
            int damage = int.Parse(command[2]);
            string attacker = command[3];

            if (heroes[heroName].HP - damage > 0)
            {
                heroes[heroName].HP -= damage;
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
            }
            else
            {
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
                heroes.Remove(heroName);
            }
        }

        static void Recharge(string[] command, Dictionary<string, Stats> heroes) 
        {
            string heroName = command[1];
            int amount = int.Parse(command[2]);

            if (heroes[heroName].MP + amount <= 200)
            {
                heroes[heroName].MP += amount;
                Console.WriteLine($"{heroName} recharged for {amount} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} recharged for {200 - heroes[heroName].MP} MP!");
                heroes[heroName].MP = 200;
            }
        }

        static void Heal(string[] command, Dictionary<string, Stats> heroes) 
        {
            string heroName = command[1];
            int amount = int.Parse(command[2]);

            if (heroes[heroName].HP + amount <= 100)
            {
                heroes[heroName].HP += amount;
                Console.WriteLine($"{heroName} healed for {amount} HP!");
            }
            else
            {
                Console.WriteLine($"{heroName} healed for {100 - heroes[heroName].HP} HP!");
                heroes[heroName].HP = 100;
            }
        }
    }
}
