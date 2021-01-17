﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) 
            : base(name, 3.50m, 50)
        {
            this.Caffeine = caffeine;
        }

        
        public double Caffeine  { get; set; }
    }
}
