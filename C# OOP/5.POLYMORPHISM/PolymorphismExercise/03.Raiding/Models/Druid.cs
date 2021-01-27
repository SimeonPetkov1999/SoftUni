using _03.Raiding.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    class Druid : BaseHero
    {
        private const int DruidPower = 80;
        public Druid(string name)
            :base(name,DruidPower)
        {

        }
        public override string CastAbility()
        {
            return string.Format(HeroMessages.heroHealed, this.GetType().Name, this.Name, this.Power);
        }
    }
}
