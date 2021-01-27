using _03.Raiding.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    class Rogue : BaseHero
    {
        private const int RoguePower = 80;
        public Rogue(string name) 
            : base(name, RoguePower)
        {
        }

        public override string CastAbility()
        {
            return string.Format(HeroMessages.heroHit, this.GetType().Name, this.Name, this.Power);
        }
    }
}
