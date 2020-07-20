using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Log
    {
        [Key]
        public int ID { get; set; }
        public int? GameID { get; set; }
        public int? FirstPlayerID { get; set; }
        public int? SecondPlayerID { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? WinPlayer { get; set; }
        public string Note { get; set; }
        public Game Game { get; set; }
    }
}
