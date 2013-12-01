namespace CI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRatingTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rating", "UserID", "dbo.User");
            DropIndex("dbo.Rating", new[] { "UserID" });
            AddForeignKey("dbo.Rating", "UserID", "dbo.User", "ID", cascadeDelete: true);
            CreateIndex("dbo.Rating", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Rating", new[] { "UserID" });
            DropForeignKey("dbo.Rating", "UserID", "dbo.User");
            CreateIndex("dbo.Rating", "UserID");
            AddForeignKey("dbo.Rating", "UserID", "dbo.User", "ID");
        }
    }
}
