using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models.Interfaces
{
    interface IHero
    {
        public string Name { get; }
        public int Power { get; }
        public string CastAbility();

    }
}
