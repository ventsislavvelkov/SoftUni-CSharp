using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace P09SimpleTextEditor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            var text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var command = input[0];

                if (command == "1")
                {
                    var someString = input[1];
                    stack.Push(text.ToString());
                    text.Append(someString);
                }
                else if (command == "2")
                {
                    var count = int.Parse(input[1]);
                    var startIndex = text.Length - count;
                    stack.Push(text.ToString());
                    text.Remove(startIndex, count);

                }
                else if (command == "3")
                {
                    var index = int.Parse(input[1]);
                    Console.WriteLine(text[index-1]);
                   
                }
                else if (command == "4" && stack.Count > 0)
                {
                    text.Clear();
                    text.Append(stack.Pop());
                }
            }
        }
    }
}
