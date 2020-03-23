using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p04StarEnigma
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();
            var pattern = @"@(?<planet>[A-Z][a-z]+)[^@\-!:>]*\:(?<population>\d+)[^@\-!:>]*!(?<attackType>A|D)![^@\-!:>]*->(?<solderCount>\d+)";
           
            for (int i = 0; i < n; i++)
            {
                var encryptedMessage = Console.ReadLine();

                var key = SpecialLetterCount(encryptedMessage);

                var decriptedMessage = DecryptMessage(encryptedMessage, key);

                var matches = Regex.Match(decriptedMessage, pattern);

                if (matches.Success)
                {
                    var planetName = matches.Groups["planet"].Value;
                    var attackType = matches.Groups["attackType"].Value;

                    if (attackType == "A")
                    {
                       attackedPlanets.Add(planetName);
                    }
                    else
                    {
                        destroyedPlanets.Add(planetName);
                    }
                }
            }

            PrintPlanet(attackedPlanets, "Attacked");
            PrintPlanet(destroyedPlanets, "Destroyed");

        }

        private static void PrintPlanet(List<string> planets, string attackType)
        {
            Console.WriteLine($"{attackType} planets: {planets.Count}");
            
            foreach (var planet in planets.OrderBy(pn=>pn))
            {
                Console.WriteLine($@"-> {planet}");
            }
        }
        private static string DecryptMessage(string encryptedMessage, int key)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                var currentCh = encryptedMessage[i];
                var newCh = (char) (currentCh - key);
                sb.Append(newCh);
            }

            return sb.ToString();
        }



        public static int SpecialLetterCount(string message)
        {
            var specialLetter = new char[] {'s', 't', 'r', 'a'};
            var specialLettersCount = 0;

            for (int i = 0; i < message.Length; i++)
            {
                var currentCh = message[i];
                if (specialLetter.Contains(Char.ToLower(currentCh)))
                {
                    specialLettersCount ++;
                }
            }

            return specialLettersCount;
        }
    }
}
