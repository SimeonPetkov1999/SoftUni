﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    //•	Duration – TimeSpan in format {hours:minutes:seconds
    //}, with a minimum length of 1 hour. (required)


    [XmlType("Play")]
    public class ImportPlaysDto
    {
        [StringLength(50, MinimumLength = 4)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        [Required]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Screenwriter { get; set; }
    }
}
