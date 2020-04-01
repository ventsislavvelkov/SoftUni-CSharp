using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace P02Password
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var pattern = @">(?<digit>\d{3})\|(?<small>[a-z]{3})\|(?<big>[A-Z]{3})\|(?<sumbol>[^<>]{3})<";

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    var digit = match.Groups["digit"].Value;
                    var small = match.Groups["small"].Value;
                    var big = match.Groups["big"].Value;
                    var sumbol = match.Groups["sumbol"].Value;
                    var password = digit + small + big + sumbol;

                    Console.WriteLine($"Password: {password}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
              

            }

        }
    }
}
