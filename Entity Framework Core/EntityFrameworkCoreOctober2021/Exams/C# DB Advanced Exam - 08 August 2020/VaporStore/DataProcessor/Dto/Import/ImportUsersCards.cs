using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersCards
    {
        [Required]
        [RegularExpression("[A-Z][a-z]+ [A-Z][a-z]+")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20,MinimumLength =3)]
        public string Username { get; set; }

        [Required]
        //[EmailAddress]
        public string Email { get; set; }

        [Range(3,103)]
        public int Age { get; set; }

        //check count > 0??
        public CardDto[] Cards { get; set; }
    }

    public class CardDto
    {
        [RegularExpression("[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]//?
        [Required]
        public string Number { get; set; }

        [Required]
        [RegularExpression("[0-9]{3}")]
        public string Cvc { get; set; }

        [EnumDataType(typeof(CardType))]
        public string Type { get; set; }
    }
}
