using System;

namespace _01ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            while (words != "end")
            {
                string reverseWord = "";

                for (int i = words.Length-1; i >= 0; i--)
                {
                    reverseWord += words[i];
                }

                Console.WriteLine($"{words} = {reverseWord}");

                words = Console.ReadLine();
            }
        }
    }
}
