namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserInfoConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ServerNumber", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 16));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "ServerNumber", c => c.Int(nullable: false));
        }
    }
}
