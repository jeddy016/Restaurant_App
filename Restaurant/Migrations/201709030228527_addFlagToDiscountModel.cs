namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFlagToDiscountModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discounts", "Selected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discounts", "Selected");
        }
    }
}
