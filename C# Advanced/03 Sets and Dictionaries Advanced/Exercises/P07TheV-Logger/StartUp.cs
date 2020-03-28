using System;
using System.Collections.Generic;
using System.Linq;

namespace P07TheV_Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                var tokkens = input.Split(" ").ToArray();

                if (input.Contains("joined"))
                {
                    var newVloger = tokkens[0];

                    if (!vloggers.ContainsKey(newVloger))
                    {
                        vloggers.Add(newVloger, new Dictionary<string, HashSet<string>>());
                        vloggers[newVloger].Add("following", new HashSet<string>());
                        vloggers[newVloger].Add("followers", new HashSet<string>());
                    }
                }
                else if (input.Contains("followed"))
                {
                    var vlogger = tokkens[0];
                    var vloggerFollowed = tokkens[2];

                    if (!vloggers.ContainsKey(vlogger) || !vloggers.ContainsKey(vloggerFollowed)
                                                       || vlogger == vloggerFollowed)
                    {
                        continue;
                    }

                    vloggers[vlogger]["following"].Add(vloggerFollowed);
                    vloggers[vloggerFollowed]["followers"].Add(vlogger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var count = 1;
            var sortedCollection = vloggers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var (username, value) in sortedCollection)
            {
                var followersCount = sortedCollection[username]["followers"].Count;
                var followingsCount = sortedCollection[username]["following"].Count;

                Console.WriteLine($"{count}. {username} : {followersCount} followers, {followingsCount} following");

                if (count == 1)
                {
                    var followersCollection = value["followers"].OrderBy(x => x).ToList();

                    foreach (var follower in followersCollection)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}
