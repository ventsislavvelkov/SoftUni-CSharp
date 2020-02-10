using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04Students
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var countOfStudents = int.Parse(Console.ReadLine());

            Storage storage = new Storage();

            for (int i = 0; i < countOfStudents; i++)
            {
                var inputStudent = Console.ReadLine().Split();
                var firstName = inputStudent[0];
                var lastName = inputStudent[1];
                var grade = double.Parse(inputStudent[2]);

                storage.Student.Add(new Students(firstName,lastName,grade));
            }

            storage.Student = storage.Student.OrderByDescending(x => x.Grade).ToList();

            Console.WriteLine(storage);
        }
    }

    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Students(string firstName, string lastName, double Grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = Grade;

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }

    class Storage
    {
        public List<Students> Student { get; set; }

        public Storage()
        {
            Student = new List<Students>();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Student);
        }
    }
}
