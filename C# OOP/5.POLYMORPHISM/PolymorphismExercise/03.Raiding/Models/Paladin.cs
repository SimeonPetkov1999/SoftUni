using _03.Raiding.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    class Paladin : BaseHero
    {
        private const int PaladinPower = 100;

        public Paladin(string name) 
            : base(name, PaladinPower)
        {
        }

        public override string CastAbility()
        {
            return string.Format(HeroMessages.heroHealed, this.GetType().Name, this.Name, this.Power);
        }
    }
}
