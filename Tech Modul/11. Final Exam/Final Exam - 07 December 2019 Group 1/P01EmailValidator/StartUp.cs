using System;
using System.Linq;

namespace P01EmailValidator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var email = Console.ReadLine();
            var input = string.Empty;
            var num = 0;

            while ((input = Console.ReadLine()) != "Complete")
            {
                var tokkens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = tokkens[0];

                if (input == "Make Upper")
                {
                    email = email.ToUpper();
                    Console.WriteLine(email);
                }
                else if (input == "Make Lower")
                {
                    email = email.ToLower();
                    Console.WriteLine(email);
                }
                else if (command == "GetDomain")
                {
                    var count = int.Parse(tokkens[1]);
                    var startIndex = email.Length - count;
                    var substring = email.Substring(startIndex, count);
                    Console.WriteLine(substring);
                }
                else if (command == "GetUsername")
                {
                    if (email.Contains('@'))
                    {
                        var endIndex = email.IndexOf('@');
                        var username = email.Substring(0, endIndex);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                    
                }
                else if (command == "Replace")
                {
                    var ch = char.Parse(tokkens[1]);
                    email = email.Replace(ch, '-');
                    Console.WriteLine(email);
                }
                else if (command == "Encrypt")
                {
                    for (int i = 0; i < email.Length; i++)
                    {
                        var currentCh = email[i];
                        num = currentCh;
                        Console.Write(num + " ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
