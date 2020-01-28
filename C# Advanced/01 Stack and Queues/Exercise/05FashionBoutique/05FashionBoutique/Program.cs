using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int capacityOfBox = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(input);

            int boxes = 0;
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var currentStack = stack.Pop();

                if (sum + currentStack > capacityOfBox)
                {
                    boxes++;
                    sum = 0;
                    sum += currentStack;
                }
                else 
                {
                    sum += currentStack;
                }
            }

            if (sum > 0)
            {
                boxes++;
            }

            Console.WriteLine(boxes);
        }
    }
}
