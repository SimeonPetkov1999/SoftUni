using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        private const double baseHeatlh = 100;
        private const int baseArmor = 50;
        private const int abilityPoints = 40;


        public Warrior(string name) 
            : base(name, baseHeatlh, baseArmor, abilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (character.Name == this.Name)
            {
                throw new InvalidOperationException($"Cannot attack self!");
            }

            if (character.IsAlive)
            {
                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
