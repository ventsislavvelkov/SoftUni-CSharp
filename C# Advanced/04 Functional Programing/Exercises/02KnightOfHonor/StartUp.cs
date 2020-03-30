using System;

namespace P02KnightOfHonor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = names =>
                Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", names));

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            printNames(input);
        }
    }
}
