using System;
using System.Text.RegularExpressions;

namespace p03MatchDates
{
    class StartUp
    {
        static void Main()
        {
            var regex = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            var matches = Console.ReadLine();

            var matchesDate = Regex.Matches(matches, regex);

            foreach (Match date in matchesDate)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
