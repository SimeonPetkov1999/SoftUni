using System;

namespace ProjectCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = Console.ReadLine();
            int numberOfProjects = int.Parse(Console.ReadLine());
            int neededHours = numberOfProjects * 3;

            Console.WriteLine($"The architect {Name} will need {neededHours} hours to complete {numberOfProjects} project/s.");

        }
    }
}
