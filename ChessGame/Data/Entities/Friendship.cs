using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Friendship
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? FriendId { get; set; }
        public DateTime? AddTime { get; set; }

        public virtual User User { get; set; }
        public virtual User Friend { get; set; }
    }
}
