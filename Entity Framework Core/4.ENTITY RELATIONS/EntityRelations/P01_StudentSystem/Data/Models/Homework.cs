using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
//o HomeworkId
//o Content(string, linking to a file, not unicode)
//o ContentType(enum – can be Application, Pdf or Zip)
//o SubmissionTime
//o StudentId
//o CourseId


    public class Homework
    {
        public Homework()
        {

        }
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public ContentType ContentType  { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public enum ContentType
    {
        Application,
        Pdf,
        Zip,
    }
}
