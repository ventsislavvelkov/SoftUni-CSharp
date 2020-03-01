using System;
using System.Linq;

namespace _08LettersChangeNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var totalSum = 0.0;

            for (int i = 0; i < input.Length; i++)
            {
                var firstLetter = input[i].ElementAt(0);
                var lastLetter = input[i].ElementAt(input[i].Length - 1);

                var number = double.Parse(new string(input[i].Skip(1).Take(input[i].Length - 2).ToArray()));

                if (char.IsUpper(firstLetter))
                {
                    number /= firstLetter - 64;
                }
                else
                {
                    number *= firstLetter - 96;
                }

                if (char.IsUpper(lastLetter))
                {
                    number -= lastLetter - 64;
                }
                else
                {
                    number += lastLetter - 96;
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
