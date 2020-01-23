using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _03simpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var values = input.Split(' ');

            var stack = new Stack<string>(values.Reverse());

            while (stack.Count > 1)
            {
                int first = int.Parse(stack.Pop());
                string command = stack.Pop();
                int second = int.Parse(stack.Pop());

                switch (command)
                {
                    case "+":
                        stack.Push((first + second).ToString());
                        break;

                    case "-":
                        stack.Push((first - second).ToString());
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
