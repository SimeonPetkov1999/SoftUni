using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    //•	Team – TeamId, Name, LogoUrl, Initials (JUV, LIV, ARS…), Budget, PrimaryKitColorId, SecondaryKitColorId, TownId
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
        }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Initials { get; set; }
        public decimal Budget { get; set; }
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; }

        [InverseProperty("HomeTeam")]
        public ICollection<Game> HomeGames { get; set; }
        [InverseProperty("AwayTeam")]
        public ICollection<Game> AwayGames { get; set; }
    }
}
