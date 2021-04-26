﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
//•	Id – Integer, Primary Key
//•	Name – text with max length 30 (required)
//•	Pseudonym – text
//•	PhoneNumber – text
//•	Albums – collection of type Album

    public class Producer
    {
        public Producer()
        {
            this.Albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        public string Pseudonym { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}