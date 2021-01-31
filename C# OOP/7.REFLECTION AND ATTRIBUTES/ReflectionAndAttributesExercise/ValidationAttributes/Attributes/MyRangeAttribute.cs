using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    class MyRangeAttribute : MyValidationAttribute
    {

        private int min;
        private int max;

        public MyRangeAttribute(int min, int max)
        {
            this.Validate(min, max);
            this.min = min;
            this.max = max;
        }
        public override bool IsValid(object obj)
        {
            if (obj is int )
            {
                int value = (int)obj;
                if (value<this.min||value>this.max)
                {
                    return false;
                }
                return true;
            }
            else
            {
                throw new InvalidOperationException("invalid type");
            }
        }
        private void Validate(int min, int max) 
        {
            if (min>max)
            {
                throw new ArgumentException("Invalid Range");
            }
        }
    }
}
