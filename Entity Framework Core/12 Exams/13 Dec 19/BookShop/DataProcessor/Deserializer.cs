using BookShop.Data.Models;
using BookShop.Data.Models.Enums;
using BookShop.DataProcessor.ImportDto;
using ProductShop.XmlHelper;

namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            const string rootElement = "Books";
            var booksDto = XMLConverter.Deserializer<ImportBookDto>(xmlString, rootElement);
            
            var books = new List<Book>();
            var sb = new StringBuilder();

            foreach (var dto in booksDto)
            {
                if (IsValid(dto))
                {
                    var date = DateTime.ParseExact(dto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    var book = new Book
                    {
                        Name = dto.Name,
                        Genre = (Genre)dto.Genre,
                        Price = dto.Price,
                        Pages = dto.Pages,
                        PublishedOn = date

                    };

                    books.Add(book);
                    sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Books.AddRange(books);
            context.SaveChanges();
            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorDtos = JsonConvert.DeserializeObject<ImportAuthorsDto[]>(jsonString);

            var sb = new StringBuilder();

            List<Author> authors = new List<Author>();

            foreach (var authorDto in authorDtos)
            {
                if (!IsValid(authorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool doesEmailExists = authors
                    .FirstOrDefault(x => x.Email == authorDto.Email) != null;

                if (doesEmailExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Email = authorDto.Email,
                    Phone = authorDto.Phone
                };

                

                foreach (var authorDtoAuthorBookDto in authorDto.Books)
                {
                    var book = context.Books.Find(authorDtoAuthorBookDto.Id);

                    if (book == null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, (author.FirstName + " " + author.LastName), author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            string result = sb.ToString().TrimEnd();

            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}