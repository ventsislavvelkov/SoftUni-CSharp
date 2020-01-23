using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _01ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var reverse = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                reverse.Push(input[i]);
            }

            while (reverse.Any())
            {
                Console.Write(reverse.Pop());
            }
        }
    }
}
