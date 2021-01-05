using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var p1 = new Person();
            var p2 = new Person(22);
            var p3 = new Person("ivan",55);
        }
    }
}
