using System;
using System.Linq;

namespace P01StringManipulatorGroup2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                var token = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = token[0];

                switch (command)
                {
                    case "Change":
                        if (text.Contains(token[1]))
                        {
                            text = text.Replace(token[1], token[2]);
                            Console.WriteLine(text);
                        }
                        break;
                    case "Includes":
                        var strings = token[1];

                        if (text.Contains(strings))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }

                        break;
                    case "End":
                         strings = token[1];
                        var startIndex = text.Length - strings.Length;
                        var substring = text.Substring(startIndex, strings.Length);
                        if (strings == substring)
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }

                        break;
                    case "Uppercase":
                        text = text.ToUpper();
                        Console.WriteLine(text);
                        break;
                    case "FindIndex":
                        var ch = token[1];
                        var index = text.IndexOf(ch);
                        Console.WriteLine(index);
                        break;
                    case "Cut":
                        startIndex = int.Parse(token[1]);
                        var lenght = int.Parse(token[2]);
                        text = text.Substring(startIndex, lenght);
                        Console.WriteLine(text);
                        break;
                }
            }
        }
    }
}
