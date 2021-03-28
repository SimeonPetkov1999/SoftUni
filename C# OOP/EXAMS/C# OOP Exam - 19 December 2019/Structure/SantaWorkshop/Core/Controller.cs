using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private int presentsDone;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            if (dwarfType == nameof(HappyDwarf))
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == nameof(SleepyDwarf))
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException($"Invalid dwarf type.");
            }

            this.dwarfs.Add(dwarf);
            return $"Successfully added {dwarfType} named {dwarfName}.";
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            var dwarf = this.dwarfs.FindByName(dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException($"The dwarf you want to add an instrument to doesn't exist!");
            }

            var instrument = new Instrument(power);
            dwarf.AddInstrument(instrument);
            return $"Successfully added instrument with power {instrument.Power} to dwarf {dwarfName}!";
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            var present = new Present(presentName, energyRequired);
            this.presents.Add(present);
            return $"Successfully added Present: {presentName}!";
        }

        public string CraftPresent(string presentName)
        {
            var readyDwarfs = this.dwarfs
                                 .Models
                                 .Where(x => x.Energy >= 50)
                                 .OrderByDescending(x => x.Energy)
                                 .ToList();

            if (readyDwarfs.Count() == 0)
            {
                throw new InvalidOperationException("There is no dwarf ready to start crafting!");
            }

            var present = this.presents.FindByName(presentName);
            var workShop = new Workshop();
            while (readyDwarfs.Any())
            {
                var currentDwarf = readyDwarfs.First();
                workShop.Craft(present, currentDwarf);
                if (currentDwarf.Energy == 0)
                {
                    this.dwarfs.Remove(currentDwarf);
                    readyDwarfs.Remove(currentDwarf);
                }

                if (present.IsDone() == true)
                {
                    break;
                }
                if (!currentDwarf.Instruments.Any())
                {
                    readyDwarfs.Remove(currentDwarf);
                }
            }

            if (present.IsDone())
            {
                this.presentsDone++;
            }

            var isDone = present.IsDone() ? "done" : "not done";
            return $"Present {presentName} is {isDone}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{presentsDone} presents are done!")
              .AppendLine($"Dwarfs info:");

            foreach (var dwarf in this.dwarfs.Models)
            {
                var countNotBrokenInstruments = dwarf.Instruments.Where(x => x.IsBroken() == false).Count();                

                sb.AppendLine($"Name: {dwarf.Name}")
                  .AppendLine($"Energy: {dwarf.Energy}")
                  .AppendLine($"Instruments: {countNotBrokenInstruments} not broken left");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
