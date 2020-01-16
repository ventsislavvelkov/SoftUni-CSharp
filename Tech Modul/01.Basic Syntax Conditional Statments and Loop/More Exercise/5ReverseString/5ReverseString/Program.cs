using System;

namespace _5ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string reverseInput = "";

            for (int i = input.Length -1; i >= 0; i--)
            {
                reverseInput +=  input.Substring(i,1);
            }

            Console.WriteLine(reverseInput);
        }
    }
}
