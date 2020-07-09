using System;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Enumerations;

namespace P01_StudentSystem.Data.Models
{
    class DatabaseSeeder
    {
        public static void StudentCoursesSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasData(new StudentCourse()
                {
                    StudentId = 2,
                    CourseId = 2,

                });
        }

        public static void StudentSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                 .HasData(new Student()
                 {
                     StudentId = 1,
                     Name = "Pesho",
                     PhoneNumber = "0888565656",
                     RegisteredOn = DateTime.UtcNow,
                     Birthday = new DateTime(1980 - 04 - 08),

                 },
                   new Student()
                   {
                       StudentId = 2,
                       Name = "Dimitar",
                       PhoneNumber = "0888565656",
                       RegisteredOn = DateTime.UtcNow,
                       Birthday = new DateTime(1970 - 02 - 12),
                   },
                   new Student
                   {
                       StudentId = 3,
                       Birthday = DateTime.UtcNow.AddDays(-200),
                       Name = "Kiril",
                       PhoneNumber = "0884034667",
                       RegisteredOn = DateTime.UtcNow.AddDays(-100)

                   });
        }

        public static void ResourceSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                .HasData(new Resource
                {
                    ResourceId = 1,
                    Name = "Youtube",
                    ResourceType = ResourceType.Video,
                    CourseId = 1,

                },
                new Resource
                {
                    ResourceId = 2,
                    Name = "Wikipedia",
                    ResourceType = ResourceType.Document,
                    CourseId = 2,
                },
                new Resource
                {
                    ResourceId = 3,
                    CourseId = 2,
                    Name = "Tech world and future technologies",
                    ResourceType = ResourceType.Other,
                    Url = "techworldfuturetechnologies.com"

                });
        }

        public static void HomeworkSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homework>()
               .HasData(new Homework()
               {
                   HomeworkId = 1,
                   Content = "Some content here",
                   ContentType = ContentType.Application,
                   CourseId = 1,
                   StudentId = 1,
                   SubmissionTime = DateTime.UtcNow
               },
               new Homework()
               {
                   HomeworkId = 2,
                   Content = "Some content here 2",
                   ContentType = ContentType.Pdf,
                   CourseId = 2,
                   StudentId = 1,
                   SubmissionTime = DateTime.UtcNow

               },
               new Homework
               {
                   HomeworkId = 3,
                   Content = "Some content here 3",
                   ContentType = ContentType.Zip,
                   CourseId = 2,
                   StudentId = 2,
                   SubmissionTime = DateTime.UtcNow

               });
        }

        public static void CourseSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasData(new Course()
                {
                    CourseId = 1,
                    Name = "Algorithms",
                    StartDate = DateTime.UtcNow,
                    EndDate = new DateTime(2010, 03, 10),
                    Price = 250.40m,
                },

                    new Course()
                    {
                        CourseId = 2,
                        Name = "Algorithms",
                        StartDate = new DateTime(2009, 03, 10),
                        EndDate = new DateTime(2020, 03, 14),
                        Price = 200,
                    },
                    new Course
                    {
                        CourseId = 3,
                        Name = "Java Web",
                        Description = "Java Web Module",
                        EndDate = DateTime.UtcNow,
                        StartDate = DateTime.UtcNow.AddDays(-50),
                        Price = 500,
                    });
        }
    }
}
