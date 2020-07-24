using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Friendship
    {
        [Key]
        public int Id { get; set; }
        public int? UserID { get; set; }
        public int? FriendID { get; set; }
        public DateTime? AddTime { get; set; }
    }
}
