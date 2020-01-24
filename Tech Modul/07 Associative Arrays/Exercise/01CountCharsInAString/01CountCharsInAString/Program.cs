using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            var letters = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                char letter = word[i];

                if (letter != ' ')
                {
                    if (!letters.ContainsKey(letter))
                    {
                        letters.Add(letter, 1);
                    }
                    else
                    {
                        letters[letter]++;
                    }
                }

            }

            foreach (var item in letters)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}