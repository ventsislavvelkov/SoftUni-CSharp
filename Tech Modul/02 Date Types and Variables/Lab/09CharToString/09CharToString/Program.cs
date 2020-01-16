using System;

namespace _09CharToString
{
    class Program
    {
        static void Main(string[] args)
        {

            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char thuth = char.Parse(Console.ReadLine());

            string concatenation = string.Join("", first, second, thuth);

            Console.WriteLine(concatenation);
            
        }
    }

}
