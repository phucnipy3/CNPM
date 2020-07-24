using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Feedback
    {
        [Key]
        public int ID { get; set; }
        public int? UserID { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public DateTime? SendTime { get; set; }
        public bool? Seen { get; set; }
        public bool? Status { get; set; }
        public User User { get; set; }
    }
}
