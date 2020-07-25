using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Elo
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? GameId { get; set; }
        public int? EloPoint { get; set; }
        public int? TotalWin { get; set; }
        public int? TotalMatches { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }
    }
}
