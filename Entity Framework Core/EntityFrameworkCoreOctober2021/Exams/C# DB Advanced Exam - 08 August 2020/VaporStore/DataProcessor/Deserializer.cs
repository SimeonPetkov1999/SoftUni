namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesInput = JsonConvert
                .DeserializeObject<ImportGamesDevGenresTags[]>(jsonString);

            var sb = new StringBuilder();
            var games = new List<Game>();

            foreach (var currentGame in gamesInput)
            {
                if (IsValid(currentGame) == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = context
                    .Developers
                    .FirstOrDefault(x => x.Name == currentGame.Developer);
                if (developer == null)
                {
                    developer = new Developer() { Name = currentGame.Developer };
                    context.Developers.Add(developer);
                }

                var genre = context
                    .Genres
                    .FirstOrDefault(x => x.Name == currentGame.Genre);
                if (genre == null)
                {
                    genre = new Genre() { Name = currentGame.Genre };
                    context.Genres.Add(genre);
                }

                var tags = new List<Tag>();
                foreach (var currentTag in currentGame.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name == currentTag);
                    if (tag == null)
                    {
                        tags.Add(new Tag { Name = currentTag });
                    }
                }
                context.Tags.AddRange(tags);
                context.SaveChanges();

                var game = new Game()
                {
                    Developer = developer,
                    Genre = genre,
                    Name = currentGame.Name,
                    Price = currentGame.Price,
                    ReleaseDate = currentGame.ReleaseDate,
                };

                foreach (var tag in currentGame.Tags)
                {
                    game.GameTags.Add(new GameTag() { Tag = context.Tags.FirstOrDefault(x => x.Name == tag) });
                }

                games.Add(game);
                sb.AppendLine($"Added {currentGame.Name} ({currentGame.Genre}) with {game.GameTags.Count()} tags");

            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersInput = JsonConvert.DeserializeObject<ImportUsersCards[]>(jsonString);

            var sb = new StringBuilder();
            var users = new List<User>();

            foreach (var currentUser in usersInput)
            {
                if (IsValid(currentUser) == false || currentUser.Cards.Any(IsValid) == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User()
                {
                    Age = currentUser.Age,
                    Email = currentUser.Email,
                    FullName = currentUser.FullName,
                    Username = currentUser.Username,
                };

                foreach (var card in currentUser.Cards)
                {
                    user.Cards.Add(new Card()
                    {
                        Cvc = card.Cvc,
                        Number = card.Number,
                        Type = Enum.Parse<CardType>(card.Type)
                    });
                }
                users.Add(user);
                sb.AppendLine($"Imported {currentUser.Username} with {currentUser.Cards.Count()} cards");
            }

            context.Users.AddRange(users);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var purchasesInput = XmlConverter.Deserializer<ImportPurchases[]>(xmlString, "Purchases", false);
            var sb = new StringBuilder();

            var purchases = new List<Purchase>();

            foreach (var currentPurchase in purchasesInput)
            {
                if (IsValid(currentPurchase) == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase()
                {
                    Card = context.Cards.FirstOrDefault(x => x.Number == currentPurchase.Card),
                    Game = context.Games.FirstOrDefault(x => x.Name == currentPurchase.title),
                    ProductKey = currentPurchase.Key,
                    Type = Enum.Parse<PurchaseType>(currentPurchase.Type),
                    Date = DateTime.ParseExact(currentPurchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),

                };
                purchases.Add(purchase);
                sb.AppendLine($"Imported {currentPurchase.title} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
