using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                Student currentStudent = new Student(input[0], input[1], double.Parse(input[2]));
                students.Add(currentStudent);
            }

            students = students.OrderBy(n => n.Grade).Reverse().ToList();

            foreach (var item in students)
            {
                item.PrintStudent();
            }



        }

        class Student
        {

            public Student(string firstName, string secondName, double grade)
            {
                this.FirstName = firstName;
                this.SecondName = secondName;
                this.Grade = grade;
            }
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public double Grade { get; set; }

            public void PrintStudent() 
            {
                Console.WriteLine($"{FirstName} {SecondName}: {Grade:f2}");
            }

        }


    }
}
