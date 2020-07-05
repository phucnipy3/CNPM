using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Game
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Describe { get; set; }

        public bool Status { get; set; }

        public Game()
        {
            Elos = new HashSet<Elo>();
            Logs = new HashSet<Log>();
            Rooms = new HashSet<Room>();
        }

        public virtual ICollection<Elo> Elos { get; set; }

        public virtual ICollection<Log> Logs { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
