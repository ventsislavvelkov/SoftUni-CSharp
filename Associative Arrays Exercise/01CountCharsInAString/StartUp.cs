using System;
using System.Collections.Generic;


namespace _01CountCharsInAString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();

            var letters = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                var letter = word[i];

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