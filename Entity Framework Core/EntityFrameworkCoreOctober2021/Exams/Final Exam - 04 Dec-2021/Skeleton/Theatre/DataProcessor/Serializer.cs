namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var topTheaters = context.Theatres
                .ToList()
                 .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                 .Select(x => new
                 {
                     Name = x.Name,
                     Halls = x.NumberOfHalls,
                     TotalIncome = x.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(x => x.Price),
                     Tickets = x.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Select(x => new
                     {
                         Price = x.Price,
                         RowNumber = x.RowNumber
                     })
                     .ToList()
                     .OrderByDescending(x => x.Price)
                 })
                 .OrderByDescending(x => x.Halls)
                 .ThenBy(x => x.Name)
                 .ToList();


            var json = JsonConvert.SerializeObject(topTheaters, Formatting.Indented);

            return json;

        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new ExportPlayDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts.Where(x => x.IsMainCharacter == true)
                                    .Select(x => new ActorDto
                                    {
                                        FullName = x.FullName,
                                        MainCharacter = $"Plays main character in '{x.Play.Title}'."

                                    }).OrderByDescending(x => x.FullName)
                                    .ToArray()
                }).OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            var xml = XmlConverter.Serialize(plays, "Plays");

            return xml;
        }
    }
}
