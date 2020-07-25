namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit02 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Eloes", new[] { "UserID" });
            DropIndex("dbo.Eloes", new[] { "GameID" });
            DropIndex("dbo.Logs", new[] { "GameID" });
            DropIndex("dbo.Rooms", new[] { "GameID" });
            DropIndex("dbo.Feedbacks", new[] { "UserID" });
            AddColumn("dbo.Games", "Description", c => c.String());
            CreateIndex("dbo.Eloes", "UserId");
            CreateIndex("dbo.Eloes", "GameId");
            CreateIndex("dbo.Logs", "GameId");
            CreateIndex("dbo.Rooms", "GameId");
            CreateIndex("dbo.Rooms", "FirstPlayerId");
            CreateIndex("dbo.Rooms", "SecondPlayerId");
            CreateIndex("dbo.Friendships", "UserId");
            CreateIndex("dbo.Friendships", "FriendId");
            CreateIndex("dbo.Messages", "SenderId");
            CreateIndex("dbo.Messages", "ReceiverId");
            CreateIndex("dbo.Feedbacks", "UserId");
            AddForeignKey("dbo.Friendships", "FriendId", "dbo.Users", "Id");
            AddForeignKey("dbo.Friendships", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Messages", "ReceiverId", "dbo.Users", "Id");
            AddForeignKey("dbo.Messages", "SenderId", "dbo.Users", "Id");
            AddForeignKey("dbo.Rooms", "FirstPlayerId", "dbo.Users", "Id");
            AddForeignKey("dbo.Rooms", "SecondPlayerId", "dbo.Users", "Id");
            DropColumn("dbo.Games", "Describe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Describe", c => c.String());
            DropForeignKey("dbo.Rooms", "SecondPlayerId", "dbo.Users");
            DropForeignKey("dbo.Rooms", "FirstPlayerId", "dbo.Users");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Messages", "ReceiverId", "dbo.Users");
            DropForeignKey("dbo.Friendships", "UserId", "dbo.Users");
            DropForeignKey("dbo.Friendships", "FriendId", "dbo.Users");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "ReceiverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.Friendships", new[] { "FriendId" });
            DropIndex("dbo.Friendships", new[] { "UserId" });
            DropIndex("dbo.Rooms", new[] { "SecondPlayerId" });
            DropIndex("dbo.Rooms", new[] { "FirstPlayerId" });
            DropIndex("dbo.Rooms", new[] { "GameId" });
            DropIndex("dbo.Logs", new[] { "GameId" });
            DropIndex("dbo.Eloes", new[] { "GameId" });
            DropIndex("dbo.Eloes", new[] { "UserId" });
            DropColumn("dbo.Games", "Description");
            CreateIndex("dbo.Feedbacks", "UserID");
            CreateIndex("dbo.Rooms", "GameID");
            CreateIndex("dbo.Logs", "GameID");
            CreateIndex("dbo.Eloes", "GameID");
            CreateIndex("dbo.Eloes", "UserID");
        }
    }
}
