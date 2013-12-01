namespace CI.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
        }
    }
}
