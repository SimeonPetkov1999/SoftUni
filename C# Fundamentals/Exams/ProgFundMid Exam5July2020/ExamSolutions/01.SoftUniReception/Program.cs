using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int studentsPerHour = firstEmployee + secondEmployee + thirdEmployee;
            int answeredQuestions = 0;
            int hours = 0;

            while (answeredQuestions < studentsCount)
            {              
                answeredQuestions += studentsPerHour;
                hours++;
                if (hours % 4 == 0)
                {
                    hours++;
                }
              
            }          
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
