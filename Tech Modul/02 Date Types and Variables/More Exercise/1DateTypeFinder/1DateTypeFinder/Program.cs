using System;

namespace _1DateTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            int isNumber = 0;
            float isFloat = 0.0f;
            char isChar = ' ';
            bool isBool;






            while (input != "END")
            {
                if (int.TryParse(input, out isNumber))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out isFloat))
                {
                    Console.WriteLine($"{input} is floating point type"); 
                }
                else if (char.TryParse(input, out isChar))
                {
                    Console.WriteLine($"{input} is character type"); 
                }
                else if (bool.TryParse(input, out isBool))
                {
                    Console.WriteLine($"{input} is boolean type"); 
                }
                else 
                {
                    Console.WriteLine($"{input} is string type"); 
                }

                
                input = Console.ReadLine(); 
            }
        }
    }
}
