using System;
using System.Collections.Generic;
using System.Linq;

namespace P02SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var setOfNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstSetSize = setOfNumbers[0];
            var secondSetSize = setOfNumbers[1];
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var currentNumber = 0;

            for (int i = 0; i < firstSetSize; i++)
            {
                currentNumber = int.Parse(Console.ReadLine());
                firstSet.Add(currentNumber);
            }

            for (int i = 0; i < secondSetSize; i++)
            {
                currentNumber = int.Parse(Console.ReadLine());
                secondSet.Add(currentNumber);
            }

            foreach (var num in firstSet)
            {
                if (secondSet.Contains(num))
                {
                    Console.Write(num + " ");
                }
            }
        }
    }
}
