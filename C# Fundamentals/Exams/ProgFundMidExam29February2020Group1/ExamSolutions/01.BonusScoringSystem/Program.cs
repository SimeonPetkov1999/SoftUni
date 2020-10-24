using System;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOFStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int bestStudentAttendedLectures = 0;

            for (int i = 0; i < numberOFStudents; i++)
            {
                int numberOfAttendances = int.Parse(Console.ReadLine());
                double currentBonus = (numberOfAttendances*1.0 / numberOfLectures) * (5 + additionalBonus);
              

                if (currentBonus > maxBonus)
                {                
                    maxBonus = currentBonus;
                    bestStudentAttendedLectures = numberOfAttendances;
                    Math.Ceiling(maxBonus);
                }
            }

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {bestStudentAttendedLectures} lectures.");
        }
    }
}
