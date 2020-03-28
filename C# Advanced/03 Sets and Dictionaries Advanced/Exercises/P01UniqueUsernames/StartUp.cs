using System;
using System.Collections.Generic;

namespace P01UniqueUsernames
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            var numberOfUsernames = int.Parse(Console.ReadLine());
            var usernames = new HashSet<string>();

            var username = string.Empty;
            
            for (int i = 0; i < numberOfUsernames; i++)
            {
                username = Console.ReadLine();
                usernames.Add(username);
            }

            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
