namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeNameRequirementsFromUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
