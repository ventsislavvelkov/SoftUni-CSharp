using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var create = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();
            var listyiterator = new ListyIterator<string>(create);
            

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(listyiterator.Move());
                        break;
                    case "Print":
                        listyiterator.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listyiterator.HasNext());
                        break;
                }
            }



        }
    }
}
