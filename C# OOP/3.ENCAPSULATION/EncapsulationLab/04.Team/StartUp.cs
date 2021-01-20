using System;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var team = new Team("softuni");
            var person = new Person("simo","petkov",18,500);

            team.AddPlayer(person);
        }
    }
}
