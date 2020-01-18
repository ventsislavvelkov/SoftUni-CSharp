using System;
using System.Linq;

namespace _5DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            char input = ' ';
            int sumbol = 0;
            string result = "";

            for (int i = 1; i <= number; i++)
            {
                input = char.Parse(Console.ReadLine());

                sumbol = (int)input + key;

                result += (char)sumbol;            
            }
            Console.Write(result);         
        }
    }
}
