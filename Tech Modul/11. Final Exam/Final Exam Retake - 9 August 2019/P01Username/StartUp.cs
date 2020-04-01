using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace P01Username
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var input = string.Empty;
            var isValidIndex = false;

            while ((input = Console.ReadLine()) !="Sign up")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                
                if (command == "Case")
                {
                    var secondCommand = tokens[1];

                    if (secondCommand == "lower")
                    {
                        text = text.ToLower();
                    }
                    else
                    {
                        text = text.ToUpper();
                    }

                    Console.WriteLine(text);
                }
                else if (command == "Reverse")
                {
                    var startIndex = int.Parse(tokens[1]);
                    var endIndex = int.Parse(tokens[2]);
                    isValidIndex = IsValidIndex(text, startIndex, endIndex);

                    if (isValidIndex)
                    {
                        for (int i = endIndex; i >= startIndex; i--)
                        {
                            var currentCh = text[i];
                            Console.Write(currentCh);
                        }

                        Console.WriteLine();
                        
                        
                    }


                }
                else if (command == "Cut")
                {
                    var substring = tokens[1];

                    if (text.Contains(substring))
                    {
                        var getStartIndex = text.IndexOf(substring[0]);
                        text = text.Remove(getStartIndex, substring.Length);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine($"The word {text} doesn't contain {substring}.");
                    }
                }
                else if (command == "Replace")
                {
                    var replace = tokens[1];

                    if (text.Contains(replace))
                    {
                        text = text.Replace(replace, "*");
                        Console.WriteLine(text);
                    }
                }
                else if (command == "Check")
                {
                    var check = tokens[1];

                    if (text.Contains(check))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {check}.");
                    }
                }
            }

        }

        private static bool IsValidIndex(string text,  int startIndex, int endIndex)
        {
            if (startIndex >=0 || text.Length > startIndex && 
                endIndex >= 0 || text.Length > endIndex)
            {
                return true;
            }

            return false;
        }
    }
}
