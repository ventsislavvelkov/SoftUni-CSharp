using System;
using System.Collections.Generic;
using System.Linq;

namespace _02BasicQueueOperations
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

            var queue = new Queue<int>();

            for (int i = 0; i < inputNSX[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < inputNSX[1]; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count != 0)
            {

                if (queue.Contains(inputNSX[2]))
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
                foreach (var stacks in queue)
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