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

            var input = Console.ReadLine();

            var result = GetBooksByAuthor(db, input);

            Console.WriteLine(result);

        }

        // 2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var bookByAgeRegistration = context.Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return String.Join(Environment.NewLine, bookByAgeRegistration);
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
            var bookByPrice = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var r in bookByPrice)
            {
                sb.AppendLine($"{r.Title} - ${r.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookNotReleased = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, bookNotReleased);



        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var bookByCategory = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var result = context.Books
                .Where(b => b.BookCategories
                    .Select(bc => new { bc.Category.Name })
                    .Any(bc => bookByCategory.Contains(bc.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return String.Join(Environment.NewLine, result);
        }

        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var inputDate = DateTime.ParseExact(date, "dd-MM-yyyy",
                CultureInfo.InvariantCulture);

            var bookReleasedBefore = context.Books
                .Where(b => b.ReleaseDate < inputDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                }).ToList();

            var sb = new StringBuilder();

            foreach (var r in bookReleasedBefore)
            {
                sb.AppendLine($"{r.Title} - {r.EditionType} - ${r.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var AuthorNamesEnding = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var r in AuthorNamesEnding)
            {
                sb.AppendLine(r.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {

            var bookTitleContaining = context.Books
                .AsEnumerable()
                .Where(b => b.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(b => b.Title)
                .OrderBy(bt => bt)
                .ToList();

            return String.Join(Environment.NewLine, bookTitleContaining);
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var bookByAuthor = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AutorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .OrderBy(b => b.BookId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var r in bookByAuthor)
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
            var totalProfitByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(bc => bc.Book.Copies * bc.Book.Price)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var t in totalProfitByCategory)
            {
                sb.AppendLine($"{t.Name} ${t.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    CategoryBooks = c.CategoryBooks
                        .Select(cb => new
                        {
                            cb.Book.Title,
                            cb.Book.ReleaseDate
                        })
                        .Take(3)
                        .OrderByDescending(cb => cb.ReleaseDate)
                        .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var m in mostRecentBooks)
            {
                sb.AppendLine($"--{m.Name}");

                foreach (var cb in m.CategoryBooks)
                {
                    sb.AppendLine($"{cb.Title} ({cb.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //15. Increase Prices
    }
}
