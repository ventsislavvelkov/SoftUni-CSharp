using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

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

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homework { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
