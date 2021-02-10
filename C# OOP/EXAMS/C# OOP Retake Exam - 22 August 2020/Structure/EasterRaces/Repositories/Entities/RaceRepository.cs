using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    class RaceRepository : Repository<IRace>
    {
        public RaceRepository() 
            : base()
        { }

        public override void Add(IRace model)
        {
            this.models.Add(model);
        }

        public override IReadOnlyCollection<IRace> GetAll()
        {
            return (IReadOnlyCollection<IRace>)this.models;
        }

        public override IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Name == name);
        }

        public override bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
