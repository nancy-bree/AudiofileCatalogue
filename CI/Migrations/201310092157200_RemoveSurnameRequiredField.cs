namespace CI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSurnameRequiredField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Author", "Surname", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Author", "Surname", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
