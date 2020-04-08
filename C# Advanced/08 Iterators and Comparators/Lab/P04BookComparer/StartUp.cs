using System;

namespace IteratorsAndComparators
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var bookOne = new Book("Animal Farm", 2003, "George Orwell");
            var bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            var bookThree = new Book("The Documents in the Case", 1930);

            var library = new Library(bookOne, bookTwo, bookThree);

        }
    }
}
