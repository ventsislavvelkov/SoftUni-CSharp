using System;

namespace P01ActionPrint
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = names =>
                Console.WriteLine(string.Join(Environment.NewLine, names));

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printNames(input);
        }
    }
}
