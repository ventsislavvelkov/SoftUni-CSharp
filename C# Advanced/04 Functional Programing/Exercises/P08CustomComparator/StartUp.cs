using System;
using System.Linq;

namespace P08CustomComparator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> sortFunc = (x, y)
                => (x % 2 == 0 && y % 2 != 0) ? -1
                : (x % 2 != 0 && y % 2 == 0) ? 1
                : x > y ? 1 : x < y ? -1 : 0;

            Array.Sort(inputNumbers, (x, y) => sortFunc(x, y));

            Action<int[]> printNumbers = numbers =>
                Console.WriteLine(string.Join(" ", numbers));

            printNumbers(inputNumbers);
        }
    }
}
