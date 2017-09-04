namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixOrderedItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderedItems", "MenuItemId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderedItems", "Name");
            DropColumn("dbo.OrderedItems", "Price");
            DropColumn("dbo.OrderedItems", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderedItems", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderedItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderedItems", "Name", c => c.String());
            DropColumn("dbo.OrderedItems", "MenuItemId");
        }
    }
}
