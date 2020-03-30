using System;
using System.Collections.Generic;
using System.Linq;

namespace P12TriFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> isLarger = (name, charsLength)
                => name.Sum(x => x) >= charsLength;

            Func<List<string>, Func<string, int, bool>, string> nameFilter =
                (inputNames, isLargerFilter) => inputNames.FirstOrDefault(x => isLarger(x, length));

            var resultName = nameFilter(names, isLarger);

            Action<string> printName = name => Console.WriteLine(name);

            printName(resultName);
        }
    }
}
