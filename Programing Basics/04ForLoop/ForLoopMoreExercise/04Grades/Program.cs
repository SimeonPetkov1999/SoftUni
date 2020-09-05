using System;

namespace _04Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            double average = 0.0;
            double percentageTop = 0;
            double percentageBetween4and499 = 0;
            double percentageBetween3and399 = 0;
            double percentageFail = 0;


            for (int i = 0; i < numberOfStudents; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade >= 5.00)
                {
                    percentageTop++;
                }

                else if (grade >= 4.00 && grade <= 4.99)
                {
                    percentageBetween4and499++;
                }

                else if (grade >= 3.00 && grade <= 3.99)
                {
                    percentageBetween3and399++;
                }

                else
                {
                    percentageFail++;
                }
                average += grade;
            }

            percentageTop = (percentageTop / numberOfStudents) * 100;
            percentageBetween4and499 = (percentageBetween4and499 / numberOfStudents) * 100;
            percentageBetween3and399 = (percentageBetween3and399 / numberOfStudents) * 100;
            percentageFail = (percentageFail / numberOfStudents) * 100;

            average = average / numberOfStudents;

            Console.WriteLine($"Top students: {percentageTop:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percentageBetween4and499:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percentageBetween3and399:f2}%");
            Console.WriteLine($"Fail: {percentageFail:f2}% ");
            Console.WriteLine($"Average: {average:f2}");
        }
    }
}
