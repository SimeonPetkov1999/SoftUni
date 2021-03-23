using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .IsUnicode(false)
                .HasMaxLength(10)
                .IsFixedLength();

            modelBuilder.Entity<Resource>()
                .Property(r => r.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Homework>()
                .Property(h => h.Content)
                .IsUnicode(false);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(x => new { x.CourseId, x.StudentId });
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
