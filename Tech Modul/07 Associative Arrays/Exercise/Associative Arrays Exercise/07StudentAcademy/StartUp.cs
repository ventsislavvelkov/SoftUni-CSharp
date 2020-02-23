using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace _07StudentAcademy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var studentAcademy = new Dictionary<string, List<double>>();

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var studentName = Console.ReadLine();
                var grade = double.Parse(Console.ReadLine());

                if (!studentAcademy.ContainsKey(studentName))
                {
                    studentAcademy.Add(studentName, new List<double>());
                }

                studentAcademy[studentName].Add(grade);

            }

            var resultList = new Dictionary<string,double>();

            foreach (var student in studentAcademy)
            {
                var avegageGrade = student.Value.Average();
                if (avegageGrade >= 4.50)
                {
                    resultList.Add(student.Key, avegageGrade);
                }
            }

            foreach (var student in resultList.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{student.Key} -> {student.Value:F2}");
            }

        }
    }
}

