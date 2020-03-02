using System;
using System.Collections.Generic;
using System.Linq;

namespace _5FilterByAge
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Startup
    {
        static void Main(string[] args)
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);
                people.Add(person);
            }

            var condition = Console.ReadLine();
            var maxAge = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<Person, string> peopleFilter = PeopleFilter(people, format);
            Func<Person, bool> ageFilter = AgeFilter(people, condition, maxAge);

            var filteredPeople = people
                .Where(ageFilter)
                .Select(peopleFilter)
                .ToList();

            foreach (var person in filteredPeople)
            {
                Console.WriteLine(person);
            }
        }

        private static Func<Person, bool> AgeFilter(List<Person> people, string condition, int maxAge)
        {
            switch (condition)
            {
                case "older": return person => person.Age >= maxAge;
                case "younger": return person => person.Age < maxAge;
                default: return null;
            }
        }

        private static Func<Person, string> PeopleFilter(List<Person> people, string format)
        {
            switch (format)
            {
                case "name": return person => $"{person.Name}";
                case "age": return person => $"{person.Age}";
                case "name age": return person => $"{person.Name} - {person.Age}";
                default: return null;
            }
        }
    }
}
