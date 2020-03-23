using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace p04StarEnigma
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var key = 3;



                for (int j = 0; j < input.Length; j++)
                {
                    var currentCh = input[j];
                    var decryptedCh = (char)(currentCh - key);
                    sb.Append(decryptedCh);

                }


            }
            Console.WriteLine(string.Join(" ", sb));
        }

        public static int SpecialLetterCount(string message)
        {
            var specialLetter = new char[] {'s', 't', 'r', 'a'};
            var specialLettersCount = 0;

            if (specialLetter.Contains(message))
            {
                specialLettersCount++;
            }

            return specialLettersCount;
        }
    }
}
