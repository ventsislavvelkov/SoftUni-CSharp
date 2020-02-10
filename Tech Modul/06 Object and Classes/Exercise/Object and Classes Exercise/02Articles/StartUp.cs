using System;
using System.Linq;

namespace _02Articles
{
    class StartUp
    {
        static void Main()
        {
            var ArticleArgs = Console.ReadLine().Split(", ").ToArray();

            var title = ArticleArgs[0];
            var content = ArticleArgs[1];
            var author = ArticleArgs[2];

            var article = new Article(title,content,author);

            var countOfCommands = int.Parse(Console.ReadLine());

            for (int q = 0; q < countOfCommands; q++)
            {
                var commandArgs = Console.ReadLine().Split(": ");

                var command = commandArgs[0];
                var value = commandArgs[1];

                if (command == "Edit" )
                {
                    var currentContent = commandArgs[1];
                    article.Edit(currentContent);
                }
                else if (command == "ChangeAuthor")
                {
                    var currentAutor = commandArgs[1];
                    article.ChangeAuthor(currentAutor);
                }
                else if (command == "Rename")
                {
                    var currentTitle = commandArgs[1];
                    article.Rename(currentTitle);
                }

            }

            Console.WriteLine(article);

        }
    }

    public class Article
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

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
