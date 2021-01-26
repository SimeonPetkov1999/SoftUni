using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Cat : Animal
    {
        public Cat(string name, string food) 
            : base(name, food)
        {
        }

        public override string ExplainSelf()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ExplainSelf())
              .Append("MEEOW");

            return sb.ToString();
        }
    }
}
