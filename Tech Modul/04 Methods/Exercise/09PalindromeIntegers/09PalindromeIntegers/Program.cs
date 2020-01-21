using System;
using System.Linq;

namespace _09PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                polindrome(input);

                input = Console.ReadLine();
            }
        }

        static void polindrome(string a)
        {
            string b = new string(a.Reverse().ToArray());

            if (a == b)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
