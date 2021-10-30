using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    //•	PlayerStatistic – GameId, PlayerId, ScoredGoals, Assists, MinutesPlayed
    public class PlayerStatistic
    {
        public int GameId { get; set; }

        [InverseProperty("PlayerStatistics")]
        public Game Game { get; set; }
        public int PlayerId { get; set; }

        [InverseProperty("PlayerStatistics")]
        public Player Player { get; set; }//?

        public int ScoredGoals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
        
    }
}
