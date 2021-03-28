using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int SleepyDwarfEnergy = 50;
        public SleepyDwarf(string name) 
            : base(name, SleepyDwarfEnergy)
        {
        }

        public override void Work()
        {
            base.Work();
            base.Energy -= 5;
        }
    }
}
