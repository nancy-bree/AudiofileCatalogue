namespace CI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageFieldToAuthorEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Author", "Image", c => c.String(maxLength: 255));
            AlterColumn("dbo.Author", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Author", "Name", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Author", "Image");
        }
    }
}
