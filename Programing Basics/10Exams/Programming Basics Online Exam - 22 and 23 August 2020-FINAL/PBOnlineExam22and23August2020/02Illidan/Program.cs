using System;

namespace _02Illidan
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int powerOfOnePerson = int.Parse(Console.ReadLine());
            int healthOfIlidan = int.Parse(Console.ReadLine());

            int powerOfPeople = numberOfPeople * powerOfOnePerson;
            int diff = Math.Abs(healthOfIlidan-powerOfPeople);
            
            if (powerOfPeople<healthOfIlidan)
            {
                Console.WriteLine($"You are not prepared! You need {diff} more points.");
            }

            else
            {
                Console.WriteLine($"Illidan has been slain! You defeated him with {diff} points.");
            }
        }
    }
}
