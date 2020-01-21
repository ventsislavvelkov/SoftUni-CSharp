using System;

namespace _06MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            FindMiddleChart(input);
        }

        static void FindMiddleChart(string text)
        {

            if (text.Length % 2 == 0)
            {
                Console.Write($"{text[text.Length / 2 - 1]}{text[text.Length / 2]}");
            }
            else
            {
                Console.WriteLine($"{text[text.Length / 2]}");
            }
        }
    }
}
