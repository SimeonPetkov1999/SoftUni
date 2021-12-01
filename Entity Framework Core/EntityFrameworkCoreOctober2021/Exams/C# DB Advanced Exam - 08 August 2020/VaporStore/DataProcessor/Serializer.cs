namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

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
					TotalPlayers = x.Games.Select(x=>x.Purchases.Count).Sum()
				}).OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id)
				.ToList();

			var json = JsonConvert.SerializeObject(games,Formatting.Indented);

			return json;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			throw new NotImplementedException();
		}
	}
}