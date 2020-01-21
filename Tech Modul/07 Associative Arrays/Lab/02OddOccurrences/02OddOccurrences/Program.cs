using System;
using System.Linq;
using System.Collections.Generic;

namespace _02OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            var toLower = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string wordToLowerCase = word.ToLower();

                if (toLower.ContainsKey(wordToLowerCase))
                {
                    toLower[wordToLowerCase]++;
                }
                else
                {
                    toLower.Add(wordToLowerCase, 1);
                }
            }
            foreach (var lower in toLower)
            {
                if (lower.Value % 2 != 0)
                {
                    Console.Write(lower.Key + " ");
                }

            }
        }
    }
}
