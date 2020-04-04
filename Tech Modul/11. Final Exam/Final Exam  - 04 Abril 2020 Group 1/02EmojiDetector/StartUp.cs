using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02EmojiDetector
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var emojiPattern = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})(\1)";
            var numberPattern = @"(?<num>[0-9])";
            var number = 1;
            var emoji = new List<string>();
            var emojiCounter = 0;

            var matchEmoji = Regex.Matches(input, emojiPattern);
            var matchNumber = Regex.Matches(input, numberPattern);

            foreach (Match match in matchNumber)
            {
                var num = int.Parse(match.Groups["num"].Value);
                number *= num;
            }

            foreach (Match matches in matchEmoji)
            {
                var first = matches.Groups["1"].Value;
                var name = matches.Groups["emoji"].Value;
                var validEmoji = first + name + first;
                var sumOfName = 0;
                emojiCounter++;

                for (int i = 0; i < name.Length; i++)
                {
                    var currentCh = name[i];
                    sumOfName += currentCh;
                }

                if (sumOfName > number)
                {
                   emoji.Add(validEmoji);
                }

            }

            Console.WriteLine($"Cool threshold: {number}");
            Console.WriteLine($"{emojiCounter} emojis found in the text. The cool ones are:");
            if (emoji.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, emoji));
            }
         

        }
    }
}
