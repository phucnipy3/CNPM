using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class MaintainceInfomation
    {
        [Key]
        public int ID { get; set; }

        public string Content { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Status { get; set; }
    }
}
