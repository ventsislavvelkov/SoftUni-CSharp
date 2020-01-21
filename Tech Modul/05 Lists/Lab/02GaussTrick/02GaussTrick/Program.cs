using System;
using System.Linq;
using System.Collections.Generic;

namespace _02GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> number = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < number.Count / 2; i++)
            {
                result.Add(number[i] + number[(number.Count - 1) - i]);
            }

            if (number.Count % 2 != 0)
            {
                result.Add(number[number.Count / 2]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
