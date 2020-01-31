using System;
using System.Collections.Generic;
using System.Linq;

namespace _03SchoolLibrary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var bookCollection = Console.ReadLine().Split("&").ToList();

            while (true)
            {
                var input = Console.ReadLine().Split(" | ").ToArray();

                if (input[0]== "Done")
                {
                    break;
                }
                else
                {
                    switch (input[0])
                    {
                        case "Add Book":

                            if (!bookCollection.Contains(input[1]))
                            {
                                bookCollection.Insert(0, input[1]);
                            }
                          
                            break;
                        case "Take Book":

                            if (bookCollection.Contains(input[1]))
                            {
                                bookCollection.Remove(input[1]);
                            }

                            break;
                        case "Swap Books":

                            if (bookCollection.Contains(input[1]) && bookCollection.Contains(input[2]))
                            {
                              var firstIndex =  bookCollection.IndexOf(input[1]);
                               var secondIndex = bookCollection.IndexOf(input[2]);
                               bookCollection[firstIndex] = input[2];
                               bookCollection[secondIndex] = input[1];
                            }

                            break;
                        case "Insert Book":

                            bookCollection.Add(input[1]);

                            break;
                        case "Check Book":

                            var index = int.Parse(input[1]);

                            if (index < bookCollection.Count && index >= 0)
                            {
                                Console.WriteLine(bookCollection[index]);
                            }
                            break;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", bookCollection));
        }
    }
}
