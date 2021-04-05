﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    class FirePotion : Item
    {
        private const int FirePotionWeigth = 5;
        public FirePotion()
            : base(FirePotionWeigth)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= 20; //?
        }
    }
}
