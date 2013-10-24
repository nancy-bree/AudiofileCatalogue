namespace CI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAuthorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Audiofile", "Title", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Author", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Author", "Surname");
            DropColumn("dbo.User", "Login");
            DropColumn("dbo.User", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Salt", c => c.String(maxLength: 64));
            AddColumn("dbo.User", "Login", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Author", "Surname", c => c.String(maxLength: 50));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Author", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Audiofile", "Title", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.User", "Username");
        }
    }
}
