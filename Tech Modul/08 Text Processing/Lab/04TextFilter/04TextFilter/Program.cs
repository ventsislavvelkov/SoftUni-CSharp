using System;

namespace _04TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannesWords = Console.ReadLine().Split(", ");

            string text = Console.ReadLine();

            while (text.Contains(bannesWords[0]) && text.Contains(bannesWords[1]))
            {
                for (int i = 0; i < bannesWords.Length; i++)
                {
                    text = text.Replace(bannesWords[i], new string('*', bannesWords[i].Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
