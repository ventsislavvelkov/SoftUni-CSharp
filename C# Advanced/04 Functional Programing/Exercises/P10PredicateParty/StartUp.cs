using System;
using System.Collections.Generic;
using System.Linq;

namespace P10PredicateParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var additionalList = new List<string>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];
                var criteria = tokens[1];
                var givenLegth = 0;
                var givenString = string.Empty;

                var isString = int.TryParse(tokens[2], out givenLegth);

                if (!isString)
                {
                    givenString = tokens[2];
                }

                Predicate<string> startsWith = name => name.StartsWith(givenString);
                Predicate<string> endsWith = name => name.EndsWith(givenString);
                Predicate<string> nameLength = name => name.Length == givenLegth;

                if (command == "Double" && criteria == "Length")
                {
                    additionalList = people.Where(x => nameLength(x)).ToList();
                    people = CopyList(additionalList, people);
                }
                else if (command == "Double" && criteria == "StartsWith")
                {
                    additionalList = people.Where(x => startsWith(x)).ToList();
                    people = CopyList(additionalList, people);
                }
                else if (command == "Double" && criteria == "EndsWith")
                {
                    additionalList = people.Where(x => endsWith(x)).ToList();
                    people = CopyList(additionalList, people);
                }
                else if (command == "Remove" && criteria == "Length")
                {
                    people.RemoveAll(x => nameLength(x));
                }
                else if (command == "Remove" && criteria == "StartsWith")
                {
                    people.RemoveAll(x => startsWith(x));
                }
                else if (command == "Remove" && criteria == "EndsWith")
                {
                    people.RemoveAll(x => endsWith(x));
                }
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Action<List<string>> printNames = names =>
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");

                printNames(people);
            }
        }

        private static List<string> CopyList(List<string> additionalList, List<string> originalList)
        {
            originalList.InsertRange(0, additionalList);

            return originalList;
        }
    }
}
