using System;
using System.Linq;

namespace _08MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();

            int equal = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                int first = numbers[i];

                for (int y = i + 1; y < numbers.Length; y++)
                {
                    int second = numbers[y];

                    if (first + second == equal)
                    {
                        Console.WriteLine($"{first} {second}");
                    }

                }
            }

        }
    }
}
