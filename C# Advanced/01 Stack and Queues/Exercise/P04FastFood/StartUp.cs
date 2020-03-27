using System;
using System.Collections.Generic;
using System.Linq;

namespace P04FastFood
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var quantityOfFood = int.Parse(Console.ReadLine());
            var isComplete = true;

            var order = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            for (int i = 0; i < order.Length; i++)
            {
                if (quantityOfFood - order[i] < 0)
                {
                    Console.WriteLine(stack.Max());
                    Console.WriteLine($"Orders left: {order[i]}");
                    isComplete = false;
                    break;
                }
                else
                {
                    quantityOfFood -= order[i];
                    stack.Push(order[i]);
                }
            }

            if (isComplete)
            {
                Console.WriteLine($"{stack.Max()}");
                Console.WriteLine("Orders complete");
            }
        }
    }
}
