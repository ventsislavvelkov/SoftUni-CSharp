using System;
using System.Collections;
using  System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace _05PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> allNumbers = new Queue<int>();

            foreach (var number in input)
            {
                if (number % 2 == 0)
                {
                    allNumbers.Enqueue(number);
                }
            }

            Console.WriteLine(string.Join(", ", allNumbers));
        }
    }
}