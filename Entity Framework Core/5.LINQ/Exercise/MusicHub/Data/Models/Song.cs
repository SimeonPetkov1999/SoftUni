using MusicHub.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
//•	Id – Integer, Primary Key
//•	Name – Text with max length 20 (required)
//•	Duration – TimeSpan(required)
//•	CreatedOn – Date(required)
//•	Genre ¬– Genre enumeration with possible values: "Blues, Rap, PopMusic, Rock, Jazz" (required)
//•	AlbumId – Integer, Foreign key
//•	Album – The song’s album
//•	WriterId – Integer, Foreign key(required)
//•	Writer – The song’s writer
//•	Price – Decimal(required)
//•	SongPerformers – Collection of type SongPerformer


    public class Song
    {
        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }


        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }
        public Album Album { get; set; }//?

        [Required]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }

    }
}
