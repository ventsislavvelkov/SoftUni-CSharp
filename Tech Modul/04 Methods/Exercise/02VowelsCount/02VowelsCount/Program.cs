using System;
using System.Linq;

namespace _02VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(VowelsCount(input));
        }

        static int VowelsCount(string a)
        {
            string[] spelling = a.ToCharArray().Select(c => c.ToString()).ToArray();
            int counter = 0;


            for (int i = 0; i < spelling.Length; i++)
            {
                if (spelling[i] == "o" || spelling[i] == "y" || spelling[i] == "e" || spelling[i] == "i" || spelling[i] == "a" || spelling[i] == "u" ||
                    spelling[i] == "O" || spelling[i] == "Y" || spelling[i] == "E" || spelling[i] == "I" || spelling[i] == "A" || spelling[i] == "U")
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
