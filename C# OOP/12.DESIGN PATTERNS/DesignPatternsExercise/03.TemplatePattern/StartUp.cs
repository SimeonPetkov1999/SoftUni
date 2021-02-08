using System;

namespace _03.TemplatePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var grain = new Grain();
            grain.Make();

            var wheat = new Wheat();
            wheat.Make();
        }
    }
}
