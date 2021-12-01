using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
//•	CardId – integer, foreign key(required)
//•	Card – the purchase’s card(required)
//•	GameId – integer, foreign key(required)
//•	Game – the purchase’s game(required)

    [XmlType("Purchase")]
    public class ImportPurchases
    {
        [XmlAttribute]
        public string title { get; set; }

        [XmlElement]
        [EnumDataType(typeof(PurchaseType))]
        [Required]
        public string Type { get; set; }

        [XmlElement]
        [RegularExpression("[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}")]
        [Required]
        public string Key { get; set; }

        [XmlElement]
        [Required]
        public string Card { get; set; }

        [XmlElement]
        [Required]
        public string Date { get; set; }
    }
}
