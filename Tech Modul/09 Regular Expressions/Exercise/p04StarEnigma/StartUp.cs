using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace p04StarEnigma
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var starEnigma = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var key = 3;
                var enigma = Encoding.ASCII.GetBytes(input); ;

                for (int j = 0; j < enigma.Length; j++)
                {
                    Console.WriteLine(enigma[i]);
                }
               // starEnigma.Add(enigma);
               // Console.WriteLine(enigma);
               // Console.WriteLine();
               // Console.WriteLine(string.Join(" ", starEnigma));

            }
        }
    }
}
