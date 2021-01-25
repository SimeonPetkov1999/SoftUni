using _08.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    class MyList : Collection, IAdd, IRemove, IUsed
    {
        public MyList()
            : base()
        {

        }
        public int Used => this.collection.Count;
        public string Remove()
        {
            var removed = this.collection[0];
            this.collection.RemoveAt(0);

            return removed;
        }
    }
}
