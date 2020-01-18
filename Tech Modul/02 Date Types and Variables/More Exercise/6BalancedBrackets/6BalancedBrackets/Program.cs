using System;

namespace _6BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            string input = " ";
            int openBrackets = 0;
            int closeBrackets = 0;

            for (int i = 0; i <= counter; i++)
            {
                input = Console.ReadLine();

                if (input == "(")
                {
                    openBrackets++;
                }
                else if (input == ")")
                {
                    closeBrackets++;
                }
            }
            if (openBrackets == closeBrackets && openBrackets != 0 && closeBrackets != 0)
            {
                Console.WriteLine("BALANCED");
            }
            else if(counter > 0 || openBrackets > closeBrackets || closeBrackets > openBrackets)
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
