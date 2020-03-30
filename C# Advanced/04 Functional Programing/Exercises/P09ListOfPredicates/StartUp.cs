using System;
using System.Collections.Generic;
using System.Linq;

namespace P09ListOfPredicates
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var endOfRange = int.Parse(Console.ReadLine());
            var divider = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var resultNumbers = Enumerable.Range(1, endOfRange).ToList();

            var currentDivider = 0;

            for (int i = 0; i < divider.Length; i++)
            {
                currentDivider = divider[i];

                Predicate<int> filterNumbers = number => number % currentDivider == 0;

                resultNumbers = resultNumbers
                    .Where(x => filterNumbers(x))
                    .ToList();
            }

            Action<List<int>> printNumbers = numbers =>
                Console.WriteLine(string.Join(" ", numbers));

            printNumbers(resultNumbers);
        }
    }
}
