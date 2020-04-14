using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = new ListyIterator<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    if (!input.Contains("Create"))
                    {
                        if (input == "Move")
                        {
                            Console.WriteLine(listyIterator.Move());
                        }
                        else if (input == "HasNext")
                        {
                            Console.WriteLine(listyIterator.HasNext());
                        }
                        else if (input == "Print")
                        {
                            listyIterator.Print();
                        }
                        else if (input == "PrintAll")
                        {
                            foreach (var item in listyIterator)
                            {
                                Console.Write($"{item} ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        List<string> elements = input
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1)
                            .ToList();

                        listyIterator.Add(elements);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
