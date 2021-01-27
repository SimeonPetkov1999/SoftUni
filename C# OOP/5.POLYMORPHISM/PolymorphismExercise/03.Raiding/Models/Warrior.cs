using _03.Raiding.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    class Warrior : BaseHero
    {
        private const int WarriorPower = 100;
        public Warrior(string name) 
            : base(name, WarriorPower)
        {
        }

        public override string CastAbility()
        {
            return string.Format(HeroMessages.heroHit, this.GetType().Name, this.Name, this.Power);
        }
    }
}
