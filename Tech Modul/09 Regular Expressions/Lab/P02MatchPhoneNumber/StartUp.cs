using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02MatchPhoneNumber
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var regex = @"(?<!\d)[+]359(\s{1}|-)2\1\d{3}\1\d{4}\b";

            var phones = Console.ReadLine();

            var phoneMatches = Regex.Matches(phones, regex);

            var matchedPhones = phoneMatches.Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
