namespace CI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRatingTable : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Rating", "UserID", "dbo.User", "ID");
            AddForeignKey("dbo.Rating", "AudiofileID", "dbo.Audiofile", "ID", cascadeDelete: true);
            CreateIndex("dbo.Rating", "UserID");
            CreateIndex("dbo.Rating", "AudiofileID");
            DropColumn("dbo.Rating", "Vote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rating", "Vote", c => c.Byte(nullable: false));
            DropIndex("dbo.Rating", new[] { "AudiofileID" });
            DropIndex("dbo.Rating", new[] { "UserID" });
            DropForeignKey("dbo.Rating", "AudiofileID", "dbo.Audiofile");
            DropForeignKey("dbo.Rating", "UserID", "dbo.User");
        }
    }
}
