using System;
using System.Text;

namespace _07RepeatString
{
    class Program
    {
        private static string RepeatString(string str, int count)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(str);
            }
            return result.ToString();
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeated = int.Parse(Console.ReadLine());

            string result = RepeatString(input, repeated);
            Console.WriteLine(result);
        }
    }
}
