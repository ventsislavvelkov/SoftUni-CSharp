using System;
using System.Text.RegularExpressions;

namespace P02MessageEncrypter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pattern =
                @"(\*|@)(?<name>[A-Z][a-z]{2,})(\1):\s{1}\[(?<first>[A-Za-z])\]\|\[(?<second>[A-Za-z])\]\|\[(?<third>[A-Za-z])\]\|$";


            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    var name = match.Groups["name"].Value;
                    var first = char.Parse(match.Groups["first"].Value);
                    var second = char.Parse(match.Groups["second"].Value);
                    var third = char.Parse(match.Groups["third"].Value);

                    Console.WriteLine($"{name}: {(int)first} {(int)second} {(int)third}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}
