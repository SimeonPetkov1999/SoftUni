﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{

    /* 
    o StudentId
    o Name(up to 100 characters, unicode)
    o PhoneNumber(exactly 10 characters, not unicode, not required)
    o RegisteredOn
    o Birthday(not required)
    */


    public class Student
    {

        public Student()
        {
            this.CourseEnrollments = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
         
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}