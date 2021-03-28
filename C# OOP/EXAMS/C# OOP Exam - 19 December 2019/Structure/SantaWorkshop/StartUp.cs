namespace SantaWorkshop
{
    using SantaWorkshop.Core;
    using SantaWorkshop.Core.Contracts;
    using System;


    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
