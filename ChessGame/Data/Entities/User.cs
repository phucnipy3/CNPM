using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? Experience { get; set; }
        public int? Permission { get; set; }
        public bool? Active { get; set; }
        public bool? Status { get; set; }
        public User()
        {
            Elos = new HashSet<Elo>();
            Feedbacks = new HashSet<Feedback>();
            Friendships = new HashSet<Friendship>();
            _Friendships = new HashSet<Friendship>();
            Messages = new HashSet<Message>();
            _Messages = new HashSet<Message>();
            Rooms = new HashSet<Room>();
            _Rooms = new HashSet<Room>();
        }
        public virtual ICollection<Elo> Elos { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Friendship> Friendships { get; set; }
        public virtual ICollection<Friendship> _Friendships { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Message> _Messages { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Room> _Rooms { get; set; }
    }
}
