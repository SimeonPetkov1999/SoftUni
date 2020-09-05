using System;

namespace _02ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFailGrade = int.Parse(Console.ReadLine());
            int numberOfProblems = 0;
            int numberOfFails = 0;
            int sumGrades = 0;
            string lastTask = null;


            while (true)
            {
                string nameOfTask = Console.ReadLine();
                if (nameOfTask=="Enough")
                {
                    double average = sumGrades*1.0 / numberOfProblems;
                    Console.WriteLine($"Average score: {average:f2}");
                    Console.WriteLine($"Number of problems: {numberOfProblems}");
                    Console.WriteLine($"Last problem: {lastTask}");
                    break;
                }
                lastTask = nameOfTask;
                int grade = int.Parse(Console.ReadLine());
                sumGrades += grade;
                numberOfProblems++;
                if (grade<=4)
                {
                    numberOfFails++;
                    if (numberOfFails == numberOfFailGrade)
                    {
                        Console.WriteLine($"You need a break, {numberOfFailGrade} poor grades.");
                        break;
                    }
                }


            }
        }
    }
}
