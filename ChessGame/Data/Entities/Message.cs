using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Message
    {
        [Key]
        public int ID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Content { get; set; }
        public DateTime? SendTime { get; set; }
    }
}
