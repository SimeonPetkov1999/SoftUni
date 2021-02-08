using System;
using System.Collections.Generic;
using System.Text;

namespace _01.PrototypePattern
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            this.sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name] 
        {
            get => this.sandwiches[name];
            set 
            {
                this.sandwiches.Add(name, value);
            }
        }
    }
}
