namespace VaporStore.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var games = context.Genres
                .Where(x => genreNames.Contains(x.Name))
                .ToList()
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Where(x => x.Purchases.Any()).ToList().Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(x => x.Tag.Name)),
                        Players = g.Purchases.Count
                    }).OrderByDescending(x => x.Players)
                      .ThenBy(x => x.Id)
                      .ToList(),
                    TotalPlayers = x.Games.Select(x => x.Purchases.Count).Sum()
                }).OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(games, Formatting.Indented);

            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var typeToCheck = Enum.Parse<PurchaseType>(storeType);

            var users = context.Users
                .Where(x => x.Cards.Any(x => x.Purchases.Any()))
                .Select(x => new ExportUserPurchases
                {
                    Username = x.Username,
                    Purchases = x.Cards.SelectMany(x => x.Purchases.Where(x => x.Type == typeToCheck))
                    .OrderBy(x => x.Date)
                    .Select(x => new PurchaseDto
                    {
                        Card = x.Card.Number,
                        Cvc = x.Card.Cvc,
                        Date = x.Date.ToString("yyyy-MM-dd HH:mm"),
                        Game = new GameDto()
                        {
                            Genre = x.Game.Genre.Name,
                            Price = (double)(x.Game.Price ==0 ? 0 :x.Game.Price),
                            Title = x.Game.Name,
                        }
                    })
                    .ToArray(),
                    TotalSpent = (double)x.Cards.SelectMany(x => x.Purchases.Where(x => x.Type == typeToCheck)).Sum(x => x.Game.Price)
                })
                 
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToList()
                .Where(u => u.Purchases.Count() > 0)
                .ToList();


            var xml = XmlConverter.Serialize(users, "Users");

            return xml;
        }
    }
}