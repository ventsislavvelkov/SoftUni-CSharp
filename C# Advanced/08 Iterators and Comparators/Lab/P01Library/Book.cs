using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year, params string[] autor)
        {
            this.Title = title;
            this.Year = year;
            this.Autors = autor.ToList();
        }
        public List<string> Autors { get; private set; }
        public string Title { get; set; }
        public int Year { get; set; }

    }
}
