using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    class CarRepository : Repository<ICar>
    {
        public CarRepository() :
            base()
        { }
        public override void Add(ICar model)
        {
            this.models.Add(model);
        }

        public override IReadOnlyCollection<ICar> GetAll()
        {
            return (IReadOnlyCollection<ICar>)this.models;
        }

        public override ICar GetByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Model == name);
        }

        public override bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
