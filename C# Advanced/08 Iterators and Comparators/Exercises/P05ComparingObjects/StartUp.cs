using System;
using System.Collections.Generic;
using System.Linq;

namespace P05ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var personinfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = personinfo[0];
                var age = int.Parse(personinfo[1]);
                var town = personinfo[2];

                var person = new Person(name, age, town);

                people.Add(person);
            }

            var matchesCount = 0;
            var n = int.Parse(Console.ReadLine());

            var personToCompare = people[n - 1];

            foreach (var person in people)
            {
                if (personToCompare.CompareTo(person) == 0)
                {
                    matchesCount++;
                }
            }

            if (matchesCount <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                var notMatchesCount = people.Count - matchesCount;
                Console.WriteLine($"{matchesCount} {notMatchesCount} {people.Count}   "); 
            }
        }
    }
}
