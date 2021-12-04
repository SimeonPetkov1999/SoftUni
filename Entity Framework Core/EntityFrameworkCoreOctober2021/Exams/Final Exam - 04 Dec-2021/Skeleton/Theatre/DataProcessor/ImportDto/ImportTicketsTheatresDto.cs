using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{ 

//•	Director – text with length[4, 30] (required)
//•	Tickets - a collection of type Ticket


//•	PlayId – integer, foreign key(required)
//•	TheatreId – integer, foreign key(required)


    public class ImportTicketsTheatresDto
    {
        [Required]
        [StringLength(30,MinimumLength =4)]
        public string Name { get; set; }

        [Required]
        [Range(1,10)]//?
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Director { get; set; }

        public TicketDto[] Tickets { get; set; }
    }

    public class TicketDto 
    {
        [Required]
        [Range(1.00,100.00)]
        public decimal Price { get; set; }

        [Required]
        [Range(1,10)]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
