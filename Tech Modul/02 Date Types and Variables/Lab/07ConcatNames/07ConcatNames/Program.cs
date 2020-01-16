using System;

namespace _07ConcatNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            string delimeter = Console.ReadLine();

            Console.WriteLine($"{first}{delimeter}{second}");
           
        }
    }
}
