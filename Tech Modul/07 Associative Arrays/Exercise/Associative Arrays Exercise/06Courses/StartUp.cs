using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualBasic;

namespace _06Courses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var coursAndStudents = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine().Split(" : ");
                var cours = input[0];

                if (cours == "end")
                {
                    break;
                }
                else
                {
                    var studentName = input[1];

                    if (!coursAndStudents.ContainsKey(cours))
                    {
                        coursAndStudents.Add(cours, new List<string>());
                    }
                    coursAndStudents[cours].Add(studentName);
                }
            }

            foreach (var course in coursAndStudents.OrderByDescending(x=>x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                Console.WriteLine($"-- {string.Join(Environment.NewLine+"-- ", course.Value.OrderBy(x=>x))}");
            }
        }
    }
} 
