using System;
using System.Linq;

namespace _3CountUppercaseWords
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];

            var strings = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            foreach (var word in strings)
            {
                Console.WriteLine(word);
            }
        }
    }
}
