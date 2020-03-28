using System;
using System.Collections.Generic;
using System.Linq;

namespace P05CountSymbols
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToCharArray();
            var letterCounts = new Dictionary<char,int>();

            for (int i = 0; i < text.Length; i++)
            {
                var currentCh = text[i];
                if (!letterCounts.ContainsKey(currentCh))
                {
                    letterCounts.Add(currentCh,0);
                }

                letterCounts[currentCh]++;
            }

            foreach (var (key,value) in letterCounts.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{key}: {value} time/s");
            }
        }
    }
}
