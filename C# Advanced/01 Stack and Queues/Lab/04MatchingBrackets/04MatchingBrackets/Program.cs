using System;
using System.Collections;
using System.Collections.Generic;

namespace _04MatchingBrackets
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < text.Length; i++)
            {
                var symbol = text[i];
                if (symbol == '(')
                {
                    stack.Push(i);
                }
                else if (symbol == ')')
                {
                    int indexOfOpenBracket = stack.Pop();

                    string result = text.Substring(indexOfOpenBracket,
                                            i - indexOfOpenBracket + 1);
                    
                    Console.WriteLine(result);

                }
            }
        }
    }
}
