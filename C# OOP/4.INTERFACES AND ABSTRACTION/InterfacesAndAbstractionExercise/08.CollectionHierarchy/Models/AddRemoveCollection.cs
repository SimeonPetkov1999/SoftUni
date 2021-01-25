using _08.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    class AddRemoveCollection :Collection, IAdd, IRemove
    {
        public AddRemoveCollection()
            : base()
        {
            
        }

        public string Remove()
        {
            var removed = this.collection[this.collection.Count - 1];
            this.collection.RemoveAt(this.collection.Count - 1);
            return removed;
        }
    }
}
