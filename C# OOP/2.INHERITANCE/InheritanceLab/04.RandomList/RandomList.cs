using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    class RandomList : List<string>
    {
        public string RandomString() 
        {
            var random = new Random();
            var index = random.Next(0, this.Count);
            var rndString = this[index];
            this.RemoveAt(index);
            return rndString;
        } 
    }
}
