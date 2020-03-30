using System;
using System.Linq;

namespace P07PredicateForNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var givenNameLenght = int.Parse(Console.ReadLine());
            var inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> filterNames = name => name.Length <= givenNameLenght;

            Action<string[]> printNames = names =>
                Console.WriteLine(string.Join(Environment.NewLine, names));

            printNames(inputNames.Where(x => filterNames(x)).ToArray());
        }
    }
}
