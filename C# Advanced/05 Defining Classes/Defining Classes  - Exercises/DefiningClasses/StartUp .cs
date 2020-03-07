using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                var personArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = personArg[0];
                var age = int.Parse(personArg[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            HashSet<Person> result = family.GetAllPeopleAbove30();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
