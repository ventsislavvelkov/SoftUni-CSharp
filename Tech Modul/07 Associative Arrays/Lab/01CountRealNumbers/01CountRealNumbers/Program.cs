using System;
using System.Linq;
using System.Collections.Generic;

namespace _01CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                            .Split()
                            .Select(double.Parse)
                            .ToArray();

            var contains = new SortedDictionary<double, int>();

            foreach (var num in numbers)
            {
                if (contains.ContainsKey(num))
                {
                    contains[num]++;
                }
                else
                {
                    contains.Add(num, 1);
                }
            }

            foreach (var number in contains)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
