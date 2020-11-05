using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string[] command = Console.ReadLine().Split(" : ");

            while (command[0]!="end")
            {
                string courseName = command[0];
                string studentName = command[1];


                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add(studentName);
                }

                else
                {
                    courses[courseName].Add(studentName);
                }

                command = Console.ReadLine().Split(" : ");
            }

            courses = courses.OrderByDescending(n => n.Value.Count)  
                .ToDictionary(n=>n.Key, m=>m.Value);


            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
               
                foreach (var student in course.Value.OrderBy(n=>n))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }

       
    }
}
