using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime? SendTime { get; set; }

        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}
