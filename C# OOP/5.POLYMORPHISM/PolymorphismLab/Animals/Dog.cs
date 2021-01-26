using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Dog : Animal
    {
        public Dog(string name, string food)
            : base(name, food)
        {
        }
        public override string ExplainSelf()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ExplainSelf())
              .Append("DJAAF");

            return sb.ToString();
        }
    }
}
