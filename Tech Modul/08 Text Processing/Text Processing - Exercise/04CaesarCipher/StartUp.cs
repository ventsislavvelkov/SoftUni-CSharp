using System;

namespace _04CaesarCipher
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var strings = Console.ReadLine();

            for (int i = 0; i < strings.Length; i++)
            {
                var chars = strings[i];

                var convert = chars + 3;

                chars = Convert.ToChar(convert);

                Console.Write(chars);
            }
        }
    }
}
