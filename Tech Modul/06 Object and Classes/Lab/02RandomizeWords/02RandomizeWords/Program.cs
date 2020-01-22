using System;
using System.Collections.Generic;
using System.Linq;

namespace _02RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                                  .Split(" ")
                                  .ToList();

            Random rnd = new Random();

            for (int i = 0; i < input.Count -1; i++)
            {
                var randomIndex = rnd.Next(0, input.Count);

                var randomEl = input[randomIndex];
                var el = input[i];

                input[randomIndex] = el;
                input[i] = randomEl;
            }

            foreach (var list in input)
            {
                Console.WriteLine(list);
            }
        }
    }
}
