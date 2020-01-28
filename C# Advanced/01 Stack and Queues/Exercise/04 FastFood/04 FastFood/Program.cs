using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Sources;

namespace _04_FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            var isComplete = true;

            int[] order = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < order.Length; i++)
            {
                if (quantityOfFood - order[i] < 0 )
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
