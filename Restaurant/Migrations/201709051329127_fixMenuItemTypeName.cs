namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixMenuItemTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuItemTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuItemTypes", "Name", c => c.Int(nullable: false));
        }
    }
}
