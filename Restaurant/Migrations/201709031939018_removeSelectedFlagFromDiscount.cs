namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSelectedFlagFromDiscount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Discounts", "Selected");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discounts", "Selected", c => c.Boolean(nullable: false));
        }
    }
}
