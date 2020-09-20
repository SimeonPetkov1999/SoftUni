using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int numberOfPeople = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)capacity / numberOfPeople);
            Console.WriteLine(courses);
        }
    }
}
