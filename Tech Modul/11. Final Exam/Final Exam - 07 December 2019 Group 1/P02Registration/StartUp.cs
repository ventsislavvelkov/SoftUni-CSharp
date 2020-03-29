using System;
using System.Text.RegularExpressions;

namespace P02Registration
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pattern = @"U\$(?<username>[A-Z][a-z]{2,})U\$P\@\$(?<password>[A-Za-z]{5,}[0-9]+)P\@\$";
            var successfulRegistration = 0;

            for (int i = 0; i < n; i++)
            {


                var input = Console.ReadLine();
                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    var username = match.Groups["username"].Value;
                    var password = match.Groups["password"].Value;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                    successfulRegistration++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
               
            }

            Console.WriteLine($"Successful registrations: {successfulRegistration}");
        }
    }
}
