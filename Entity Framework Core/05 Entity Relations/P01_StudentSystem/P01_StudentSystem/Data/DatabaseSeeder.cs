using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Enumerations;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class DatabaseSeeder
    {
        public static void StudentsSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasData(
                new Student
                {
                    StudentId = 1,
                    Birthday = DateTime.UtcNow,
                    Name = "Ivan",
                    PhoneNumber = "0884222222",
                    RegisteredOn = DateTime.UtcNow.AddDays(-16)
                },
                new Student
                {
                    StudentId = 2,
                    Birthday = DateTime.UtcNow.AddDays(-220),
                    Name = "Misho",
                    PhoneNumber = "0884033322",
                    RegisteredOn = DateTime.UtcNow.AddDays(-150)
                });
        }

        public static void CoursesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasData(
                new Course
                {
                    CourseId = 1,
                    Name = "C# OOP",
                    Description = "Module",
                    EndDate = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow.AddDays(-35),
                    Price = 350,
                },
                new Course
                {
                    CourseId = 2,
                    Name = "C# Advanced",
                    Description = "Module",
                    EndDate = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow.AddDays(-24),
                    Price = 400,
                },
                new Course
                {
                    CourseId = 3,
                    Name = "Java Web",
                    Description = "Module",
                    EndDate = DateTime.UtcNow,
                    StartDate = DateTime.UtcNow.AddDays(-56),
                    Price = 500,
                }
                );
        }

        public static void ResourcesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasData(
                new Resource
                {
                    ResourceId = 1,
                    CourseId = 1,
                    Name = "SoftUni",
                    ResourceType = ResourceType.Document,
                    Url = "softuni.com"
                },
                new Resource
                {
                    ResourceId = 2,
                    CourseId = 2,
                    Name = "Smart Academy",
                    ResourceType = ResourceType.Video,
                    Url = "Smart.bg"
                },
                new Resource
                {
                    ResourceId = 3,
                    CourseId = 3,
                    Name = "Techno world",
                    ResourceType = ResourceType.Presentation,
                    Url = "technoworld.com"
                },
                new Resource
                {
                    ResourceId = 4,
                    CourseId = 2,
                    Name = "Tech world",
                    ResourceType = ResourceType.Other,
                    Url = "technoforall.com"
                });
        }

        public static void HomeworkSubmissionsSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>()
                .HasData(
                new Homework
                {
                    HomeworkId = 1,
                    Content = "Some one",
                    ContentType = ContentType.Application,
                    CourseId = 1,
                    StudentId = 1,
                    SubmissionTime = DateTime.UtcNow
                },
                new Homework
                {
                    HomeworkId = 2,
                    Content = "Some two",
                    ContentType = ContentType.Pdf,
                    CourseId = 2,
                    StudentId = 1,
                    SubmissionTime = DateTime.UtcNow
                },
                new Homework
                {
                    HomeworkId = 3,
                    Content = "Some three",
                    ContentType = ContentType.Zip,
                    CourseId = 2,
                    StudentId = 2,
                    SubmissionTime = DateTime.UtcNow
                });
        }

        public static void StudentCourseSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasData(
                    new StudentCourse
                    {
                        StudentId = 1,
                        CourseId = 1
                    },
                    new StudentCourse
                    {
                        StudentId = 2,
                        CourseId = 2
                    });
        }
    }
}
