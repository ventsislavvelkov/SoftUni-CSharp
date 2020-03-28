using System;
using System.Linq;
using System.Collections.Generic;

namespace P08Ranking
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var submissions = new Dictionary<string, Dictionary<string, int>>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                var tokens = input.Split(":");
                var contestName = tokens[0];
                var contestPassword = tokens[1];

                contests.Add(contestName, contestPassword);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var tokens = input.Split("=>");
                var contestName = tokens[0];
                var contestPassword = tokens[1];
                var username = tokens[2];
                var points = int.Parse(tokens[3]);

                if (!contests.ContainsKey(contestName) || contests[contestName] != contestPassword)
                {
                    continue;
                }

                if (!submissions.ContainsKey(username))
                {
                    submissions.Add(username, new Dictionary<string, int>());
                }

                if (!submissions[username].ContainsKey(contestName))
                {
                    submissions[username].Add(contestName, points);
                }

                if (submissions[username][contestName] < points)
                {
                    submissions[username][contestName] = points;
                }
            }

            var bestCandidate = submissions
                .OrderByDescending(x => x.Value.Values.Sum())
                .FirstOrDefault();

            var bestCandidateName = bestCandidate.Key;
            var bestCandidatePoints = bestCandidate.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidateName} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var (key, value) in submissions.OrderBy(x => x.Key))
            {
                Console.WriteLine(key);

                foreach (var (contestName, points) in value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestName} -> {points}");
                }
            }
        }
    }
}
