using System;
using System.Text.RegularExpressions;

namespace p2BossRush
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine()); 

            var pattern = @"\|(?<boss>[A-Z]{4,})\|:#(?<title>[A-Z]?[a-z]+ [A-Z]?[a-z]+)#";

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var regex = Regex.Match(input, pattern);

                if (regex.Success)
                {
                    var name = regex.Groups["boss"].Value;
                    var title = regex.Groups["title"].Value;

                    Console.WriteLine($"{name}, The {title}");
                    Console.WriteLine($">> Strength: {name.Length}");
                    Console.WriteLine($">> Armour: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
