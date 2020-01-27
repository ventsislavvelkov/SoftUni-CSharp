﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01BasicStackOperations
{
    class Program
    {
        static void Main()
        {
            int[] inputNSX = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] numbers = new int[inputNSX[0]];

            bool isTrue = false;
            var smallestNumber = int.MaxValue;

            numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < inputNSX[0]; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < inputNSX[1]; i++)
            {
                stack.Pop();
            }

            if (stack.Count != 0)
            {

                if (stack.Contains(inputNSX[2]))
                {
                    isTrue = true;
                }
            }
            else
            {
                smallestNumber = 0;
            }

            if (isTrue)
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (var stacks in stack)
                {
                    if (smallestNumber > stacks)
                    {
                        smallestNumber = stacks;
                    }
                }

                Console.WriteLine(smallestNumber);
            }
        }
    }
}
