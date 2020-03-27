using System;
using System.Collections.Generic;
using System.Linq;

namespace P03MaximumAndMinimumElement
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var minminimum = int.MaxValue;
            var maximum = int.MinValue;

            while (number != 0)
            {
                number--;
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    stack.Push(input[1]);
                }
                else if (input[0] == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (input[0] == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (input[0] == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }

            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
