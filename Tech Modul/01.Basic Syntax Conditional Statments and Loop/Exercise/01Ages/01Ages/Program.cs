using System;

namespace _01Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number >=0 && number <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (number >= 3 && number <= 13)
            {
                Console.WriteLine("child");
            }
            else if (number >= 14 && number <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (number >= 20 && number <= 65)
            {
                Console.WriteLine("adult");
            }
            else if (number >= 66)
            {
                Console.WriteLine("elder");
            }
        }
    }
}
