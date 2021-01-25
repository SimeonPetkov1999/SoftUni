using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    interface IBuyer
    {
        public void BuyFood();
        public int Food { get;}
        public string Name { get; }
    }
}
