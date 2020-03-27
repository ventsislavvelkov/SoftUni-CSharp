using System;
using System.Linq;
using System.Collections.Generic;

namespace P08BalancedParentheses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var stackOfParanteses = new Stack<char>();
            var input = Console.ReadLine().ToCharArray();

            var openParaneteses = new char[] { '(', '{', '[' };

            bool isValid = true;

            foreach (var ch in input)
            {
                if (openParaneteses.Contains(ch))
                {
                    stackOfParanteses.Push(ch);
                    continue;
                }

                if (stackOfParanteses.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stackOfParanteses.Peek() == '(' && ch == ')')
                {
                    stackOfParanteses.Pop();
                }
                else if (stackOfParanteses.Peek() == '[' && ch == ']')
                {
                    stackOfParanteses.Pop();
                }
                else if (stackOfParanteses.Peek() == '{' && ch == '}')
                {
                    stackOfParanteses.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
