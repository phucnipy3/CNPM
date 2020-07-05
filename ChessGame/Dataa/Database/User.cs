using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public decimal Experience { get; set; }

        public bool Active { get; set; }

        public bool Status { get; set; }

        public User()
        {
            Elos = new HashSet<Elo>();
            Feedbacks = new HashSet<Feedback>();
        }

        public virtual ICollection<Elo> Elos { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
