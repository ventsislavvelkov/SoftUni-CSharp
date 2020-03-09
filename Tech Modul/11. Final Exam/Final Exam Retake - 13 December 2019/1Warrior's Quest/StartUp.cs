using System;
using System.Text;

namespace _1Warrior_s_Quest
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var skills = Console.ReadLine();

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];

                if (command == "For")
                {
                    break;
                }

                if (command == "GladiatorStance")
                {
                    skills = skills.ToUpper();
                    Console.WriteLine(skills);
                }
                else if (command == "DefensiveStance")
                {
                    skills = skills.ToLower();
                    Console.WriteLine(skills);
                }
                else if (command == "Dispel")
                {
                    var index = int.Parse(input[1]);
                    var letter = char.Parse(input[2]);

                    if (skills.Length > index &&  index >= 0)
                    {
                        StringBuilder sb = new StringBuilder(skills);
                        sb[index] = letter;
                        skills = sb.ToString();
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }
                else if (command == "Target")
                {
                    var secondCommand = input[1];
                    var subString = input[2];

                    if (secondCommand == "Change")
                    {
                        var secondSubstring = input[3];
                       skills = skills.Replace(subString, secondSubstring);
                    }
                    else if (secondCommand == "Remove")
                    {
                        var takeIndex = skills.IndexOf(subString);
                        skills = skills.Remove(takeIndex,subString.Length);
                    }

                    Console.WriteLine(skills);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
            }

        }
    }
}
