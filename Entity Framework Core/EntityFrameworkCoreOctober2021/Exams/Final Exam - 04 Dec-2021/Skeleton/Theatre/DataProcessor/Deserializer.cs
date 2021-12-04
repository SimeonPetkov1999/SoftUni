namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var playsInput = XmlConverter.Deserializer<ImportPlaysDto[]>(xmlString, "Plays", false);

            var sb = new StringBuilder();
            var plays = new List<Play>();

            foreach (var currentPlay in playsInput)
            {
                var duration = TimeSpan.Parse(currentPlay.Duration);

                if (IsValid(currentPlay) == false || duration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var playToAdd = new Play
                {
                    Title = currentPlay.Title,
                    Duration = duration,
                    Rating = currentPlay.Rating,
                    Genre = Enum.Parse<Genre>(currentPlay.Genre),
                    Description = currentPlay.Description,
                    Screenwriter = currentPlay.Screenwriter
                };

                plays.Add(playToAdd);
                sb.AppendLine(string.Format(SuccessfulImportPlay, playToAdd.Title, playToAdd.Genre, playToAdd.Rating));
            }

            context.AddRange(plays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var castsInput = XmlConverter.Deserializer<ImportCastDto[]>(xmlString, "Casts", false);

            var sb = new StringBuilder();
            var casts = new List<Cast>();

            foreach (var currentCast in castsInput)
            {
                if (IsValid(currentCast) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast()
                {
                    FullName = currentCast.FullName,
                    IsMainCharacter = currentCast.IsMainCharacter,
                    PhoneNumber = currentCast.PhoneNumber,
                    PlayId = currentCast.PlayId
                };

                casts.Add(cast);
                sb.AppendLine(string.Format(SuccessfulImportActor, currentCast.FullName, currentCast.IsMainCharacter == true ? "main" : "lesser"));
            }

            context.AddRange(casts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var input = JsonConvert.DeserializeObject<ImportTicketsTheatresDto[]>(jsonString);
            var sb = new StringBuilder();

            var theatres = new List<Theatre>();

            foreach (var currentTheatre in input)
            {
                if (IsValid(currentTheatre) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theareToAdd = new Theatre()
                {
                    Name = currentTheatre.Name,
                    NumberOfHalls = currentTheatre.NumberOfHalls,
                    Director = currentTheatre.Director
                };

                foreach (var ticket in currentTheatre.Tickets)
                {
                    if (IsValid(ticket) == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    theareToAdd.Tickets.Add(new Ticket()
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId//?
                    });
                }

                theatres.Add(theareToAdd);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, theareToAdd.Name, theareToAdd.Tickets.Count));
                context.Theatres.Add(theareToAdd);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd() ;
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
