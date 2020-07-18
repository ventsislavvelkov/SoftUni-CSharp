using System;
using System.Linq;
using System.Text;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext(); 
           // DbInitializer.ResetDatabase(db);

            var input = Console.ReadLine();

            var result = GetBooksByAgeRestriction(db, input);

            Console.WriteLine(result);

        }
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
    }
}
