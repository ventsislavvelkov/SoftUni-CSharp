using System;

namespace _03CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            CharactersInRange(first, second);
        }

        static void CharactersInRange(char a, char b)
        {

            for (int i = a + 1; i < b; i++)
            {
                char output = Convert.ToChar(i);
                Console.Write($"{output} ");
            }
        }
    }
}
