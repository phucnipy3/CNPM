using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public int? GameId { get; set; }
        public int? FirstPlayerId { get; set; }
        public int? SecondPlayerId { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }

        public Game Game { get; set; }
        public virtual User FirstPlayer { get; set; }
        public virtual User SecondPlayer { get; set; } 
    }
}
