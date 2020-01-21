using System;
using System.Linq;
using System.Collections.Generic;

namespace _03WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = int.Parse(Console.ReadLine());

            var words = new Dictionary<string, List<string>>();

            for (int i = 0; i < total; i++)
            {
                var word = Console.ReadLine();
                var sinonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words[word] = new List<string>();
                }

                words[word].Add(sinonym);
            }

            foreach (var ithem in words)
            {
                var word = ithem.Key;
                var sinomyn = ithem.Value;
                Console.WriteLine($"{word} - {string.Join(", ", sinomyn)}");
            }
        }
    }
}
