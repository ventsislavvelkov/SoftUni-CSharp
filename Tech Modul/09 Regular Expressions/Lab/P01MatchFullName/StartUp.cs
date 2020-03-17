using System;
using System.Text.RegularExpressions;

namespace P01MatchFullName
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var regex = @"\b[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+\b";
            var names = Console.ReadLine();

            MatchCollection matchedNames = Regex.Matches(names, regex);

            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
