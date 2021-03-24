using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    //•	Country – CountryId, Name
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
