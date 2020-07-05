using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Elo
    {
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        [Key, Column(Order = 1)]
        public int GameID { get; set; }

        public int EloPoint { get; set; }

        public int TotalWin { get; set; }

        public int TotalMatches { get; set; }

        public User User { get; set; }

        public Game Game { get; set; }
    }
}
