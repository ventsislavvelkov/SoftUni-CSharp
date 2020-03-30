using System;
using System.Collections.Generic;
using System.Linq;

namespace P11ThePartyReservationFilterModule
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var originalList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var copiedList = new List<string>(originalList);
            var filteredList = new List<string>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Print")
            {
                var commandArgs = input.Split(";");
                var command = commandArgs[0];
                var filterType = commandArgs[1];
                var filterParameter = commandArgs[2];

                Predicate<string> startsWith = name => name.StartsWith(filterParameter);
                Predicate<string> endsWith = name => name.EndsWith(filterParameter);

                Func<string, int, bool> length = (x, y) => x.Length == y;
                Func<string, string, bool> contains = (x, y) => x.Contains(y);

                if (filterType == "Starts with")
                {
                    filteredList = originalList
                        .Where(x => startsWith(x))
                        .ToList();
                }
                else if (filterType == "Ends with")
                {
                    filteredList = originalList
                        .Where(x => endsWith(x))
                        .ToList();
                }
                else if (filterType == "Length")
                {
                    filteredList = originalList
                        .Where(x => length(x, int.Parse(filterParameter)))
                        .ToList();
                }
                else if (filterType == "Contains")
                {
                    filteredList = originalList
                        .Where(x => contains(x, filterParameter))
                        .ToList();
                }

                switch (command)
                {
                    case "Add filter":
                        copiedList.RemoveAll(x => filteredList.Contains(x));
                        break;
                    case "Remove filter":
                        copiedList.AddRange(filteredList);
                        copiedList = copiedList.Distinct().ToList();
                        break;
                }
            }

            Action<List<string>> printNames = names =>
            Console.WriteLine(string.Join(" ", names));

            originalList.RemoveAll(x => !copiedList.Contains(x));

            printNames(originalList);
        }
    }
}
