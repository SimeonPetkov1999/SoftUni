using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var Name = personInfo[0];
                var Age = int.Parse(personInfo[1]);

                var currentPerson = new Person(Name, Age);
                family.AddMember(currentPerson);
            }

            var peopleToPrint = family.GetPeopleOlderThan30();

            foreach (var person in peopleToPrint)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }           
        }
    }
}
