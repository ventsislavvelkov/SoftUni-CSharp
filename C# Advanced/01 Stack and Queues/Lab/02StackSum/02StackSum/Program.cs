using System;
using System.Collections.Generic;
using System.Linq;

namespace _02StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>(input);

            var sum = 0;

            while (true)
            {
                var inputCommand = Console.ReadLine().ToLower().Split();
                var command = inputCommand[0];

                if (command == "end")
                {
                    break;
                }
                else
                {
                    var first = int.Parse(inputCommand[1]);

                    if (command == "add")
                    {
                        var second = int.Parse(inputCommand[2]);
                        
                        stack.Push(first);
                        stack.Push(second);
                    }
                    else if(command == "remove")
                    {
                        if (stack.Count >= first)
                        {
                            for (var i = 0; i < first; i++)
                            {
                                stack.Pop();
                            }
                        }
                    }

                }

            }

            sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
