using System;
using System.Collections.Generic;
using System.Linq;

namespace _03Article_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfArticles = int.Parse(Console.ReadLine());

            var storage = new Storage(); 
            for (int i = 1; i <= numberOfArticles; i++)
            {
                string[] currentArticle = Console.ReadLine().Split(", ");
                string title = currentArticle[0];
                string content = currentArticle[1];
                string author = currentArticle[2];

                storage.Articles.Add(new Article(title, content, author));
            }

            var inputCriteria = Console.ReadLine();

            if (inputCriteria == "title")
            {
                storage.Articles = storage.Articles.OrderBy(x => x.Title).ToList(); 
            }
            else if (inputCriteria == "content")
            {
                storage.Articles = storage.Articles.OrderBy(x => x.Content).ToList(); 
            }
            else if (inputCriteria == "author")
            {
                storage.Articles = storage.Articles.OrderBy(x => x.Author).ToList(); 
            }

            Console.WriteLine(storage); 
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Storage
    {
        public List<Article> Articles { get; set; }

        public Storage()
        {
            Articles = new List<Article>();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Articles);
        }
    }
}