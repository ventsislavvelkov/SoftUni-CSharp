using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DatingApp
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var inputMale = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var inputFemale = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            var male = new Stack<int>(inputMale);
            var female = new Queue<int>(inputFemale);

            var matches = 0;

            while (male.Any() && female.Any())
            {
                var curMale = male.Peek();
                var curFemale = female.Peek();

                if (curFemale <= 0)
                {
                    female.Dequeue();
                    if (!female.Any())
                    {
                        break;
                    }

                    continue;
                }

                if (curMale <= 0)
                {
                    male.Pop();
                    if (!male.Any())
                    {
                        break;
                    }
                    continue;
                }

                if (curMale % 25 == 0)
                {
                    male.Pop();

                    if (!male.Any())
                    {
                        break;
                    }
                    male.Pop();
                    continue;
                }

                if (curFemale % 25 == 0)
                {
                    female.Dequeue();

                    if (!female.Any())
                    {
                        break;
                    }
                    female.Dequeue();
                    continue;
                }

                if (curFemale == curMale)
                {
                    matches++;
                    male.Pop();
                    female.Dequeue();
                }
                else
                {
                    female.Dequeue();
                    male.Pop();
                    if (curMale - 2 > 0)
                    {
                        male.Push(curMale - 2);
                    }
                    
                }
            }

            Console.WriteLine($"Matches: {matches}");
            Console.WriteLine(male.Any() ? $"Males left: {string.Join(", ", male)}" : "Males left: none");
            Console.WriteLine(female.Any() ? $"Females left: {string.Join(", ", female)}" : "Females left: none");
        }
    }
}
