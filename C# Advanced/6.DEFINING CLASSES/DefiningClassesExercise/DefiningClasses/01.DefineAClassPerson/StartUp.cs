using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var p1 = new Person()
            {
                Name = "Pesho",
                Age = 15
            };

            var p2 = new Person();
            p2.Name = "Ivan";
            p2.Age = 18;
        }
    }
}
