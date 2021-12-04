﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.Data.Models
{
    public class Theatre
    {

        //•	Id – integer, Primary Key
        //•	Name – text with length[4, 30] (required)
        //•	NumberOfHalls – sbyte between[1…10] (required)
        //•	Director – text with length[4, 30] (required)
        //•	Tickets - a collection of type Ticket

        public Theatre()
        {
            this.Tickets = new HashSet<Ticket>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        public string Director { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
