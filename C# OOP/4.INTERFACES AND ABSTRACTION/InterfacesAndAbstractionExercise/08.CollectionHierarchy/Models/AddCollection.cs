using _08.CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    class AddCollection :Collection, IAdd
    {
        public AddCollection()
            :base()
        {
           
        }
        public override int Add(string item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}
