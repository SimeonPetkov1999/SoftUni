using EasterRaces.Models.Drivers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    class DriverRepository : Repository<IDriver>
    {
        public DriverRepository() 
            : base()
        { }
        public override void Add(IDriver model)
        {
            this.models.Add(model);
        }

        public override IReadOnlyCollection<IDriver> GetAll()
        {
            return (IReadOnlyCollection<IDriver>)this.models;
        }

        public override IDriver GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }

        public override bool Remove(IDriver model)
        {
            return this.models.Remove(model);
        }
    }
}
