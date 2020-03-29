using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace P03InboxManager
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inboxManager = new Dictionary<string, List<string>>();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                var tokkens = input.Split("->",StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = tokkens[0];
                var username = tokkens[1];

                if (command == "Add")
                {
                    if (!inboxManager.ContainsKey(username))
                    {
                        inboxManager.Add(username, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                }
                else if (command == "Send")
                {
                    var message = tokkens[2];

                    if (inboxManager.ContainsKey(username))
                    {
                        inboxManager[username].Add(message);
                    }
                }
                else if (command == "Delete")
                {
                    if (inboxManager.ContainsKey(username))
                    {
                        inboxManager.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }

            Console.WriteLine($"Users count: {inboxManager.Keys.Count}");


            foreach (var (key, value) in inboxManager
                        .OrderByDescending(x => x.Value.Count)
                        .ThenBy(x => x.Key))
            {
                Console.WriteLine(key);
               
                if (value.Count > 0)
                {
                    Console.WriteLine($" - {string.Join(Environment.NewLine + " - ", value)}");
                }
              
            }
        }
    }
}
