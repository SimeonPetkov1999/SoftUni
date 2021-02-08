using System;
using System.Collections.Generic;
using System.Text;

namespace _03.TemplatePattern
{
    class Wheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering Ingredients for Wheat Bread");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the Wheat Bread (35 minutes)");
        }
    }
}
