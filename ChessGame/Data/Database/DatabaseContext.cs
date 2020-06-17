﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Data
{
    public class DatabaseContext : DbContext
    {
        public static string StringConnection = @"Data source=(local);initial catalog=CNPM;integrated security=True;MultipleActiveResultSets=True";

        public DatabaseContext() : base(StringConnection) { }

        public virtual DbSet<Elo> Elos { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<MaintainceInfomation> MaintainceInfomations { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
