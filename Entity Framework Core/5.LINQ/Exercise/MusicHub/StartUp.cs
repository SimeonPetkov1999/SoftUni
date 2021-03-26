namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportAlbumsInfo(context, 9));
            //Console.WriteLine(ExportSongsAboveDuration(context,120));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                 .Albums
                 .Where(x => x.ProducerId == producerId)
                 .Select(x => new
                 {
                     x.Name,
                     x.ReleaseDate,//?
                     ProducerName = x.Producer.Name,
                     AlbumSongs = x.Songs.Select(x => new
                     {
                         SongName = x.Name,
                         Price = x.Price,
                         SongWriterName = x.Writer.Name
                     })
                     .OrderByDescending(x => x.SongName)
                     .ThenBy(x => x.SongWriterName)
                     .ToList(),
                     TotalPrice = x.Songs.Sum(x => x.Price)
                 })
                 .OrderByDescending(x => x.TotalPrice)
                 .ToList();


            var sb = new StringBuilder();

            foreach (var album in albums)
            {

                sb.AppendLine($"-AlbumName: {album.Name}")
                  .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}")
                  .AppendLine($"-ProducerName: {album.ProducerName}")
                  .AppendLine($"-Songs:");
                int songCount = 1;
                foreach (var song in album.AlbumSongs)
                {
                    sb.AppendLine($"---#{songCount++}")
                      .AppendLine($"---SongName: {song.SongName}")
                      .AppendLine($"---Price: {song.Price}")
                      .AppendLine($"---Writer: {song.SongWriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
            }

            return sb.ToString().TrimEnd();

            var result = context
                .Producers
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Select(x => new
                {
                    AlbumName = x.Name,
                    ReleaseDate = x.ReleaseDate,
                    ProducerName = x.Producer.Name,
                    AlbumSong = x.Songs.Select(y => new
                    {
                        SongName = y.Name,
                        Price = y.Price,
                        Writer = y.Writer.Name
                    })
                    .OrderByDescending(y => y.SongName)
                    .ThenBy(y => y.Writer)
                    .ToList(),
                    AlbumPrice = x.Price
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in result)
            {
                int counter = 0;
                sb.AppendLine($"-AlbumName: {item.AlbumName}")
                .AppendLine($"-ReleaseDate: {item.ReleaseDate.ToString("MM/dd/yyyy")}")
                .AppendLine($"-ProducerName: {item.ProducerName}")
                .AppendLine($"-Songs:");
                foreach (var song in item.AlbumSong)
                {
                    counter++;
                    sb.AppendLine($"---#{counter}")
                    .AppendLine($"---SongName: {song.SongName}")
                    .AppendLine($"---Price: {song.Price:f2}")
                    .AppendLine($"---Writer: {song.Writer}");
                }
                sb.AppendLine($"-AlbumPrice: {item.AlbumPrice:f2}");
            }


            return sb.ToString().TrimEnd();

        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context
                .Songs
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    Name = x.Name,
                    PerformerFullName = x.SongPerformers.Select(x => x.Performer.FirstName + " " + x.Performer.LastName).FirstOrDefault(),
                    WriterName = x.Writer.Name,
                    AlbumProducer = x.Album.Producer.Name,
                    Duration = x.Duration
                })
                .OrderBy(x=>x.Name)
                .ThenBy(x=>x.WriterName)
                .ThenBy(x=>x.PerformerFullName)
                .ToList();

            var sb = new StringBuilder();

            int num = 1;

//            -Song #1
//-- - SongName: Away
//  -- - Writer: Norina Renihan
//---Performer: Lula Zuan
//---AlbumProducer: Georgi Milkov
//---Duration: 00:05:35

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{num++}")
                  .AppendLine($"---SongName: {song.Name}")
                  .AppendLine($"---Writer: {song.WriterName}")
                  .AppendLine($"---Performer: {song.PerformerFullName}")
                  .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                  .AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
