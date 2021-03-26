using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
//•	Id – Integer, Primary Key
//•	FirstName – text with max length 20 (required) 
//•	LastName – text with max length 20 (required) 
//•	Age – Integer(required)
//•	NetWorth – decimal (required)
//•	PerformerSongs – collection of type SongPerformer

    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public decimal NetWorth { get; set; }
        public ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
