using System;
using System.Text;

namespace _02RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ");

            StringBuilder result = new StringBuilder();
            int count = 0;

            foreach (string word in words)
            {
                count = word.Length;

                for (int i = 1; i <= count; i++)
                {
                    result.Append(word);
                }
            }

            Console.WriteLine(result);

         
        }
    }
}
