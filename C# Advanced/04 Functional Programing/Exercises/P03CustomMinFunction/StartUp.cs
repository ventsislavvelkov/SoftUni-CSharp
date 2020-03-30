using System;
using System.Linq;

namespace P03CustomMinFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> minNumbers = numbers =>
            {
                var minValue = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < minValue)
                    {
                        minValue = number;
                    }
                }

                return minValue;
            };

            Action<int> printMinValue = minNumber =>
                Console.WriteLine(minNumber);

            printMinValue(minNumbers(inputNumbers));
        }
    }
}
