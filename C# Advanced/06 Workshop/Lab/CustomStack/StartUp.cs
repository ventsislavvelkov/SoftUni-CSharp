using System;
using System.Diagnostics;
using System.Linq;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new MyStack<int>();
            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

          
            stack.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine(string.Join(", ", stack.Where(x=>x%2==0)));
        }
    }
}
