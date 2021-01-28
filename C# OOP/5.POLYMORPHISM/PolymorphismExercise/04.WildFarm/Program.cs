using _04.WildFarm.Core;
using _04.WildFarm.Core.Interfaces;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
