using System;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext db = new BookShopContext(); 
           // DbInitializer.ResetDatabase(db);

            //var input = Console.ReadLine();

            var result = GetBooksByPrice(db);

            Console.WriteLine(result);

        }

        // 2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var result = context.Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return String.Join(Environment.NewLine, result);
        }

        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBook = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, goldenBook);
        }

        // 4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var result = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var r in result)
            {
                sb.AppendLine($"{r.Title} - ${r.Price}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
