using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace MessageTranslator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            
            var pattern = @"!(?<name>[A-Z][a-z]{2,})!:\[(?<message>[A-Za-z]{8,})\]";

            for (int i = 0; i < n; i++)
            {

                var input = Console.ReadLine();
                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    var name = match.Groups["name"].Value;
                    var message = match.Groups["message"].Value;
                    var numbers = Encoding.ASCII.GetBytes(message);

                    Console.Write($"{name}: ");
                    Console.WriteLine(string.Join(" ", numbers));
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
