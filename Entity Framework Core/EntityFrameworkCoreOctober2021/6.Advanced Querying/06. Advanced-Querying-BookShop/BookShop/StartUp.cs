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
            //DbInitializer.ResetDatabase(db);
            //
            var result = RemoveBooks(db);
            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var isParsed = Enum.TryParse(command, true, out AgeRestriction test);

            var books = context.Books
                .Where(x => x.AgeRestriction == test)
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .Select(x => x.Title)
                .ToList();

            var sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
               .Where(x => x.Price >= 40)
               .Select(x => new { x.Title, x.Price })
               .OrderByDescending(x=>x.Price)
               .ToList();

            var sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} - ${item.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year) 
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new { x.BookId, x.Title })
                .OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksByCategory(BookShopContext context, string input) 
        {
            var categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(x => x.BookCategories.Any(x=>categories.Contains(x.Category.Name.ToLower())))
                .Select(x=>x.Title)
                .OrderBy(x=>x);


            var sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string input) 
        {
            var date = DateTime.ParseExact(input, "dd-MM-yyyy",CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate < date)
                .Select(x => new 
                {
                    x.ReleaseDate, 
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            var sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} - {item.EditionType} - ${item.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var names = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => x.FirstName + ' ' + x.LastName)
                .OrderBy(x => x)
                .ToList();


            var sb = new StringBuilder();
            foreach (var item in names)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input) 
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    x.BookId,
                    x.Title,
                    Name = x.Author.FirstName + " " + x.Author.LastName,
                })
                .OrderBy(x => x.BookId)
                .ToList();


            var sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} ({item.Name})");
            }

            return sb.ToString().TrimEnd();

        }

        public static int CountBooks(BookShopContext context, int lengthCheck) 
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return books;
        }

        public static string CountCopiesByAuthor(BookShopContext context) 
        {
            var authors = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    Count = x.Books.Sum(x=>x.Copies)
                })
                .OrderByDescending(x => x.Count);

            var sb = new StringBuilder();

            foreach (var item in authors)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.Count}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context) 
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x=>x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in categories)
            {
                sb.AppendLine($"{item.Name} ${item.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context) 
        {
            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(x => new
                    {
                        BookName = x.Book.Title,
                        Year = x.Book.ReleaseDate.Value.Year,
                        x.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.ReleaseDate)
                    .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in categories)
            {
                sb.AppendLine($"--{item.Name}");
                foreach (var book in item.Books)
                {
                    sb.AppendLine($"{book.BookName} ({book.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context) 
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010);

            foreach (var item in books)
            {
                item.Price += 5;
            }


            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context) 
        {
            var books = context.Books.Where(x => x.Copies < 4200);
            var count = books.Count();
            context.Books.RemoveRange(books);
            context.SaveChanges();
            return count;
        }
    }
}
