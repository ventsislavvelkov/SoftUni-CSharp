using System;
using System.Linq;

namespace P06ReverseAndExclude
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var givenInteger = int.Parse(Console.ReadLine());

            Func<int[], int[]> reverseFunction = numbers =>
            {
                numbers = numbers.Reverse().ToArray();

                return numbers;
            };

            Predicate<int> divisibleNumbers = x => x % givenInteger != 0;

            Action<int[]> printNumbers = numbers =>
                Console.WriteLine(string.Join(" ", numbers));

            inputNumbers = reverseFunction(inputNumbers);
            printNumbers(inputNumbers.Where(x => divisibleNumbers(x)).ToArray());
        }
    }
}
