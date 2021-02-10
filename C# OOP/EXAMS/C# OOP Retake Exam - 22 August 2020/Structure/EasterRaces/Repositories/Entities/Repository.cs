using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected ICollection<T> models;
        protected Repository()
        {
            this.models = new List<T>();
        }
        public abstract void Add(T model);


        public abstract IReadOnlyCollection<T> GetAll();


        public abstract T GetByName(string name);


        public abstract bool Remove(T model);

    }
}
