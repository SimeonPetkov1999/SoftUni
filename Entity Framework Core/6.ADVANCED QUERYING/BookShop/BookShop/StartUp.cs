namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var commandRestriction = Enum.Parse<AgeRestriction>(command, true);
            var titles = context
                .Books
                .Select(x => new { x.AgeRestriction, x.Title })
                .Where(x => x.AgeRestriction == commandRestriction)
                .OrderBy(x => x.Title)
                .ToList();

            var sb = new StringBuilder();

            foreach (var title in titles)
            {
                sb.AppendLine(title.Title);
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context
                .Books
                .Where(x => (int)x.EditionType == 2 && x.Copies < 5000)
                .Select(x => new { x.Title, x.BookId })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var title in titles)
            {
                sb.AppendLine(title.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Select(x => new { x.Title, x.Price })
                .Where(x => x.Price >= 40)
                .OrderByDescending(x => x.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new { x.Title, x.BookId })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var titles = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            var books = context
                .Books
                .Where(x => x.BookCategories.Any(x => titles.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var newDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context
                .Books
                .Where(x => x.ReleaseDate < newDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate.Value)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + ' ' + x.LastName)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine(author);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    x.Title,
                    AuthorName = x.Author.FirstName + ' ' + x.Author.LastName,
                    x.BookId
                })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var countOfBooks = context
                .Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return countOfBooks;
        }

        public static string CountCopiesByAuthor(BookShopContext context) 
        {
            var countForAuthors = context
                .Authors
                .Select(x => new
                {
                    Copies = x.Books.Sum(x => x.Copies),
                    Name = x.FirstName + ' ' + x.LastName
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            var sb = new StringBuilder();

            foreach (var author in countForAuthors)
            {
                sb.AppendLine($"{author.Name} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context) 
        {
            var categories = context
                .Categories
                .Select(x => new
                {
                    x.Name,
                    Sum = x.CategoryBooks.Select(x => x.Book.Price * x.Book.Copies).Sum()
                })
                .ToList()
                .OrderByDescending(x => x.Sum)
                .ThenBy(x => x.Name);

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Sum:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context) 
        {
            var categories = context
                .Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(x => new
                    {
                        x.Book.Title,
                        x.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.ReleaseDate)
                    .Take(3)
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context) 
        {
            var books = context
                .Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context) 
        {
            var books = context
                .Books
                .Where(x => x.Copies < 4200)
                .ToList();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();
            return books.Count;
        }

    }
}
