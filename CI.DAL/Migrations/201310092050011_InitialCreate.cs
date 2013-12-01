namespace CI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audiofile",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        AuthorID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                        Year = c.Int(),
                        Description = c.String(maxLength: 256),
                        Filename = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Author", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AudiofileID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Vote = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 64),
                        Salt = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Audiofile", new[] { "GenreID" });
            DropIndex("dbo.Audiofile", new[] { "AuthorID" });
            DropForeignKey("dbo.Audiofile", "GenreID", "dbo.Genre");
            DropForeignKey("dbo.Audiofile", "AuthorID", "dbo.Author");
            DropTable("dbo.User");
            DropTable("dbo.Rating");
            DropTable("dbo.Genre");
            DropTable("dbo.Author");
            DropTable("dbo.Audiofile");
        }
    }
}
