using System;
using System.Text;

namespace _06ReplaceRepeatingChars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var strings = Console.ReadLine();

            var builder = new StringBuilder();
            builder.Append(strings[0]);
            var lastChar = 0;

            for (int i = 1; i < strings.Length; i++)
            {
                var currentChar = strings[i];

                if (currentChar != strings[lastChar])
                {
                    builder.Append(currentChar);
                }

                lastChar = i;
            }

            Console.WriteLine(builder);
        }
    }
}
