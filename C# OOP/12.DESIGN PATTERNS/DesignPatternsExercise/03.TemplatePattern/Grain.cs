using System;
using System.Collections.Generic;
using System.Text;

namespace _03.TemplatePattern
{
    class Grain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Gathering Ingredients for Grain Bread");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Baking the Grain Bread (25 minutes)");
        }
    }
}
