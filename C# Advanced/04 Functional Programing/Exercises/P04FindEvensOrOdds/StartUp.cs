using System;
using System.Collections.Generic;
using System.Linq;

namespace P04FindEvensOrOdds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var bounds = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lowerBound = bounds[0];
            var upperBound = bounds[1];
            var command = Console.ReadLine();
            var numbers = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> isOddNumber = x => x % 2 != 0;
            Predicate<int> isEvenNumber = x => x % 2 == 0;

            Action<List<int>> printNumbers = oddOrEvenNumbers =>
                Console.WriteLine(string.Join(" ", oddOrEvenNumbers));

            if (command == "odd")
            {
                printNumbers(numbers.Where(x => isOddNumber(x)).ToList());
            }
            else
            {
                printNumbers(numbers.Where(x => isEvenNumber(x)).ToList());
            }
        }
    }
}
