using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {

            while (dwarf.Energy != 0 &&
                   dwarf.Instruments.Any(x => x.IsBroken() == false) &&
                   present.IsDone() == false)
            {
                if (dwarf.Instruments.Any())
                {
                    var intrument = dwarf.Instruments.First();
                    dwarf.Work();
                    intrument.Use();
                    present.GetCrafted();
                    

                    if (intrument.IsBroken())
                    {
                        dwarf.Instruments.Remove(intrument);
                    }
                }
            }
        }
    }
}
