using System.Data.Entity;

namespace Data.Entities
{
    public class DatabaseContext : DbContext
    {
        public const string StringConnection = ConnectionString.DEFAULT;

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
        public virtual DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>()
                .HasOptional(x => x.Sender)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasOptional(x => x.Receiver)
                .WithMany(x => x._Messages)
                .HasForeignKey(x => x.ReceiverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Friendship>()
                .HasOptional(x => x.User)
                .WithMany(x => x.Friendships)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Friendship>()
                .HasOptional(x => x.Friend)
                .WithMany(x => x._Friendships)
                .HasForeignKey(x => x.FriendId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasOptional(x => x.FirstPlayer)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.FirstPlayerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasOptional(x => x.SecondPlayer)
                .WithMany(x => x._Rooms)
                .HasForeignKey(x => x.SecondPlayerId)
                .WillCascadeOnDelete(false);
        }
    }
}
