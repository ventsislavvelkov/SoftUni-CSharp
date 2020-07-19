using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore.Internal;

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

            //var input = int.Parse(Console.ReadLine());

            var result = CountCopiesByAuthor(db);

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
                sb.AppendLine($"{r.Title} - ${r.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var result = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, result);



        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var category = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var result = context.Books
                .Where(b => b.BookCategories
                    .Select(bc => new {bc.Category.Name})
                    .Any(bc => category.Contains(bc.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return String.Join(Environment.NewLine, result);
        }

        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy",
                CultureInfo.InvariantCulture);

            var result = context.Books
                .Where(b => b.ReleaseDate < targetDate)
                .OrderByDescending(b=>b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                }).ToList();
            
            var sb = new StringBuilder();

            foreach (var r in result)
            {
                sb.AppendLine($"{r.Title} - {r.EditionType} - ${r.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();
            
           var sb = new StringBuilder();

           foreach (var r in result)
           {
               sb.AppendLine(r.FullName);
           }

           return sb.ToString().TrimEnd();
        }

        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {

            var result = context.Books
                .AsEnumerable()
                .Where(b => b.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => b.Title)
                .OrderBy(bt => bt)
                .ToList();

            return String.Join(Environment.NewLine, result);
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var result = context.Books
                .Where(b => b.Author.LastName.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AutorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var r in result)
            {
                sb.AppendLine($"{r.Title} ({r.AutorFullName})");
            }

            return sb.ToString().TrimEnd();

        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var numberOfBook = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return numberOfBook;
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var totalBooksCopies = context.Authors
                .Select(a => new
                {
                    AutorFullName = a.FirstName + " " + a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var t in totalBooksCopies)
            {
                sb.AppendLine($"{t.AutorFullName} - {t.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //13. Profit by Category

        public static string GetTotalProfitByCategory(BookShopContext context)
        {

        }

    }
}
 