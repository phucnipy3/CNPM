using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public int? GameId { get; set; }
        public int? FirstPlayerId { get; set; }
        public int? SecondPlayerId { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? WinPlayer { get; set; }
        public string Note { get; set; }
        public Game Game { get; set; }
    }
}
