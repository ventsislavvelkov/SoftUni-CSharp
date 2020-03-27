using System;
using System.Collections.Generic;
using System.Linq;

namespace P05FashionBoutique
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var capacityOfBox = int.Parse(Console.ReadLine());
            var stack = new Stack<int>(input);

            var boxes = 0;
            var sum = 0;

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
