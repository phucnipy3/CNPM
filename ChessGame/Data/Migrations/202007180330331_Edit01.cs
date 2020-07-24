namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit01 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Eloes", "GameID", "dbo.Games");
            DropForeignKey("dbo.Eloes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Logs", "GameID", "dbo.Games");
            DropForeignKey("dbo.Rooms", "GameID", "dbo.Games");
            DropForeignKey("dbo.Feedbacks", "UserID", "dbo.Users");
            DropIndex("dbo.Eloes", new[] { "UserID" });
            DropIndex("dbo.Eloes", new[] { "GameID" });
            DropIndex("dbo.Logs", new[] { "GameID" });
            DropIndex("dbo.Rooms", new[] { "GameID" });
            DropIndex("dbo.Feedbacks", new[] { "UserID" });
            AlterColumn("dbo.Eloes", "UserID", c => c.Int());
            AlterColumn("dbo.Eloes", "GameID", c => c.Int());
            AlterColumn("dbo.Eloes", "EloPoint", c => c.Int());
            AlterColumn("dbo.Eloes", "TotalWin", c => c.Int());
            AlterColumn("dbo.Eloes", "TotalMatches", c => c.Int());
            AlterColumn("dbo.Games", "Status", c => c.Boolean());
            AlterColumn("dbo.Logs", "GameID", c => c.Int());
            AlterColumn("dbo.Logs", "FirstPlayerID", c => c.Int());
            AlterColumn("dbo.Logs", "SecondPlayerID", c => c.Int());
            AlterColumn("dbo.Logs", "EndTime", c => c.DateTime());
            AlterColumn("dbo.Logs", "WinPlayer", c => c.Boolean());
            AlterColumn("dbo.Rooms", "GameID", c => c.Int());
            AlterColumn("dbo.Rooms", "FirstPlayerID", c => c.Int());
            AlterColumn("dbo.Rooms", "SecondPlayerID", c => c.Int());
            AlterColumn("dbo.Rooms", "Active", c => c.Boolean());
            AlterColumn("dbo.Rooms", "Status", c => c.Boolean());
            AlterColumn("dbo.Users", "Experience", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Users", "Permission", c => c.Int());
            AlterColumn("dbo.Users", "Active", c => c.Boolean());
            AlterColumn("dbo.Users", "Status", c => c.Boolean());
            AlterColumn("dbo.Feedbacks", "UserID", c => c.Int());
            AlterColumn("dbo.Feedbacks", "SendTime", c => c.DateTime());
            AlterColumn("dbo.Feedbacks", "Seen", c => c.Boolean());
            AlterColumn("dbo.Feedbacks", "Status", c => c.Boolean());
            AlterColumn("dbo.Friendships", "UserID", c => c.Int());
            AlterColumn("dbo.Friendships", "FriendID", c => c.Int());
            AlterColumn("dbo.Friendships", "AddTime", c => c.DateTime());
            AlterColumn("dbo.MaintainceInfomations", "StartTime", c => c.DateTime());
            AlterColumn("dbo.MaintainceInfomations", "EndTime", c => c.DateTime());
            AlterColumn("dbo.MaintainceInfomations", "Status", c => c.Boolean());
            AlterColumn("dbo.Messages", "SenderID", c => c.Int());
            AlterColumn("dbo.Messages", "ReceiverID", c => c.Int());
            AlterColumn("dbo.Messages", "SendTime", c => c.DateTime());
            AlterColumn("dbo.Notifications", "TimeBegin", c => c.DateTime());
            AlterColumn("dbo.Notifications", "TimeEnd", c => c.DateTime());
            AlterColumn("dbo.Notifications", "Status", c => c.Boolean());
            CreateIndex("dbo.Eloes", "UserID");
            CreateIndex("dbo.Eloes", "GameID");
            CreateIndex("dbo.Logs", "GameID");
            CreateIndex("dbo.Rooms", "GameID");
            CreateIndex("dbo.Feedbacks", "UserID");
            AddForeignKey("dbo.Eloes", "GameID", "dbo.Games", "ID");
            AddForeignKey("dbo.Eloes", "UserID", "dbo.Users", "ID");
            AddForeignKey("dbo.Logs", "GameID", "dbo.Games", "ID");
            AddForeignKey("dbo.Rooms", "GameID", "dbo.Games", "ID");
            AddForeignKey("dbo.Feedbacks", "UserID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "UserID", "dbo.Users");
            DropForeignKey("dbo.Rooms", "GameID", "dbo.Games");
            DropForeignKey("dbo.Logs", "GameID", "dbo.Games");
            DropForeignKey("dbo.Eloes", "UserID", "dbo.Users");
            DropForeignKey("dbo.Eloes", "GameID", "dbo.Games");
            DropIndex("dbo.Feedbacks", new[] { "UserID" });
            DropIndex("dbo.Rooms", new[] { "GameID" });
            DropIndex("dbo.Logs", new[] { "GameID" });
            DropIndex("dbo.Eloes", new[] { "GameID" });
            DropIndex("dbo.Eloes", new[] { "UserID" });
            AlterColumn("dbo.Notifications", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Notifications", "TimeEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "TimeBegin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Messages", "SendTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Messages", "ReceiverID", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "SenderID", c => c.Int(nullable: false));
            AlterColumn("dbo.MaintainceInfomations", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.MaintainceInfomations", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MaintainceInfomations", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Friendships", "AddTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Friendships", "FriendID", c => c.Int(nullable: false));
            AlterColumn("dbo.Friendships", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Feedbacks", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Feedbacks", "Seen", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Feedbacks", "SendTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Feedbacks", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Active", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Permission", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Experience", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Rooms", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Rooms", "Active", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Rooms", "SecondPlayerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "FirstPlayerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "GameID", c => c.Int(nullable: false));
            AlterColumn("dbo.Logs", "WinPlayer", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Logs", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Logs", "SecondPlayerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Logs", "FirstPlayerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Logs", "GameID", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Eloes", "TotalMatches", c => c.Int(nullable: false));
            AlterColumn("dbo.Eloes", "TotalWin", c => c.Int(nullable: false));
            AlterColumn("dbo.Eloes", "EloPoint", c => c.Int(nullable: false));
            AlterColumn("dbo.Eloes", "GameID", c => c.Int(nullable: false));
            AlterColumn("dbo.Eloes", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "UserID");
            CreateIndex("dbo.Rooms", "GameID");
            CreateIndex("dbo.Logs", "GameID");
            CreateIndex("dbo.Eloes", "GameID");
            CreateIndex("dbo.Eloes", "UserID");
            AddForeignKey("dbo.Feedbacks", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "GameID", "dbo.Games", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Logs", "GameID", "dbo.Games", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Eloes", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Eloes", "GameID", "dbo.Games", "ID", cascadeDelete: true);
        }
    }
}
