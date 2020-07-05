namespace Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eloes",
                c => new
                {
                    UserID = c.Int(nullable: false),
                    GameID = c.Int(nullable: false),
                    EloPoint = c.Int(nullable: false),
                    TotalWin = c.Int(nullable: false),
                    TotalMatches = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.UserID, t.GameID })
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GameID);

            CreateTable(
                "dbo.Games",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Describe = c.String(),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Logs",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    GameID = c.Int(nullable: false),
                    FirstPlayerID = c.Int(nullable: false),
                    SecondPlayerID = c.Int(nullable: false),
                    EndTime = c.DateTime(nullable: false),
                    WinPlayer = c.Boolean(nullable: false),
                    Note = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);

            CreateTable(
                "dbo.Rooms",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    GameID = c.Int(nullable: false),
                    FirstPlayerID = c.Int(nullable: false),
                    SecondPlayerID = c.Int(nullable: false),
                    Active = c.Boolean(nullable: false),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    UserName = c.String(),
                    Password = c.String(),
                    Name = c.String(),
                    Avatar = c.String(),
                    Phone = c.String(),
                    Email = c.String(),
                    Experience = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Active = c.Boolean(nullable: false),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Feedbacks",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    UserID = c.Int(nullable: false),
                    Email = c.String(),
                    Content = c.String(),
                    SendTime = c.DateTime(nullable: false),
                    Seen = c.Boolean(nullable: false),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);

            CreateTable(
                "dbo.Friendships",
                c => new
                {
                    UserID = c.Int(nullable: false),
                    FriendID = c.Int(nullable: false),
                    AddTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.UserID, t.FriendID });

            CreateTable(
                "dbo.MaintainceInfomations",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Content = c.String(),
                    StartTime = c.DateTime(nullable: false),
                    EndTime = c.DateTime(nullable: false),
                    Status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    SenderID = c.Int(nullable: false),
                    ReceiverID = c.Int(nullable: false),
                    Content = c.String(),
                    SendTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "UserID", "dbo.Users");
            DropForeignKey("dbo.Eloes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Rooms", "GameID", "dbo.Games");
            DropForeignKey("dbo.Logs", "GameID", "dbo.Games");
            DropForeignKey("dbo.Eloes", "GameID", "dbo.Games");
            DropIndex("dbo.Feedbacks", new[] { "UserID" });
            DropIndex("dbo.Rooms", new[] { "GameID" });
            DropIndex("dbo.Logs", new[] { "GameID" });
            DropIndex("dbo.Eloes", new[] { "GameID" });
            DropIndex("dbo.Eloes", new[] { "UserID" });
            DropTable("dbo.Messages");
            DropTable("dbo.MaintainceInfomations");
            DropTable("dbo.Friendships");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
            DropTable("dbo.Logs");
            DropTable("dbo.Games");
            DropTable("dbo.Eloes");
        }
    }
}
