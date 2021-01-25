using _08.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    abstract class Collection : IAdd
    {
        protected List<string> collection;
        public Collection()
        {
            this.collection = new List<string>();
        }

        public virtual int Add(string item) 
        {
            this.collection.Insert(0, item);
            return 0;
        }
        
    }
}
