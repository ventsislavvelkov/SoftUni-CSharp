using System;

namespace P01ActivationKeys
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Generate")
            {
                var tokens = input.Split(">>>");
                var command = tokens[0];

                if (command == "Contains")
                {
                    var substring = tokens[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"{text} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }

                }
                else if (command == "Flip")
                {
                    var secondCommand = tokens[1];
                    var startIndex = int.Parse(tokens[2]);
                    var endIndex = int.Parse(tokens[3]) - startIndex;

                    var change = text.Substring(startIndex, endIndex);

                    var oldstring = change;
                    change = secondCommand == "Upper" ? change.ToUpper() : change.ToLower();

                    text = text.Replace(oldstring, change);

                    Console.WriteLine(text);

                }
                else if (command == "Slice")
                {
                    var start = int.Parse(tokens[1]);
                    var end = int.Parse(tokens[2]) - start;

                    text = text.Remove(start, end);
                    Console.WriteLine(text);

                }
            }

            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}
