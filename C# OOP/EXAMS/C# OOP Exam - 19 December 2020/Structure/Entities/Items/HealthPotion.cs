using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    class HealthPotion : Item
    {
        private const int ItemWeight = 5;
        public HealthPotion() 
            : base(ItemWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += 20; //?
        }
    }
}
