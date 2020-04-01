using System;
using System.Collections.Generic;
using System.Linq;

namespace P03Followers
{
    class Follower
    {
        public Follower(int likes = 0, int comments = 0)
        {
            Likes = likes;
            Comments = comments;
        }

        public int Likes { get; set; }

        public int Comments { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            var followers = new Dictionary<string, Follower>();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Log out")
            {
                var tokens = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var username = tokens[1];

                if (command == "New follower")
                {
                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, new Follower());
                    }
                }
                else if (command == "Like")
                {
                    var countLike = int.Parse(tokens[2]);
                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, new Follower());
                    }

                    followers[username].Likes += countLike;


                }
                else if (command == "Comment")
                {

                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, new Follower());
                    }

                    followers[username].Comments += 1;
                }
                else if (command == "Blocked")
                {
                    if (followers.ContainsKey(username))
                    {
                        followers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
            }

            Console.WriteLine($"{followers.Keys.Count} followers");

            followers = followers
                .OrderByDescending(x => x.Value.Likes)
                .ThenBy(x => x.Key)
                .ToDictionary(x=>x.Key,x=>x.Value);

            foreach (var follower in followers)
            {
                var total = follower.Value.Likes + follower.Value.Comments;
                Console.WriteLine($"{follower.Key}: {total}");
            }
        }
    }
}
