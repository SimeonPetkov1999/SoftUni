using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count { get => this.students.Count; }

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            if (student == null)
            {
                return "Student not found";
            }
            this.students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            var subjectInfo = this.students.Where(s => s.Subject == subject).ToList();
            if (subjectInfo.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}")
              .AppendLine("Students:");

            foreach (var student in subjectInfo)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }
            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName) =>
            this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
    }
}
