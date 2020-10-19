using System;
using System.Collections.Generic;

namespace _05.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split();

            List<Student> students = new List<Student>();

            while (inputData[0] != "end")
            {
                string firstName = inputData[0];
                string lastName = inputData[1];
                int age = int.Parse(inputData[2]);
                string hometown = inputData[3];

                Student currentStudent = new Student();

                currentStudent.FirstName = firstName;
                currentStudent.LastName = lastName;
                currentStudent.Age = age;
                currentStudent.City = hometown;

                if (IsStudentExisting(students,firstName,lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = hometown;
                }
                else
                {
                    students.Add(currentStudent);
                }
            
                inputData = Console.ReadLine().Split();
            }

            string city = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.City == city)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        static bool IsStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }
            }
            return false;
        }

        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }
            return existingStudent;
        }

        public class Student
        {
            public string FirstName;
            public string LastName;
            public int Age;
            public string City;
        }
    }
}
