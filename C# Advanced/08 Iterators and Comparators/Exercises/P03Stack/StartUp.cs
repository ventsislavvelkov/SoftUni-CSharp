using System;

namespace P03Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack<int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];

                if (command == "Push")
                {
                    for (int currentNumber = 1; currentNumber < tokens.Length; currentNumber++)
                    {
                        stack.Push(int.Parse(tokens[currentNumber]));
                    }
                }
                else if (command == "Pop")
                {
                    stack.Pop();
                }
            }

            foreach (var number in stack)
            {
                Console.WriteLine(number);
            }

            foreach (var number in stack)
            {
                Console.WriteLine(number);
            }

        }
    }
}
