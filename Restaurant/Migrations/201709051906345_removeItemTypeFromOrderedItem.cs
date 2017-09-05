namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeItemTypeFromOrderedItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedItems", "MenuItemTypeId", "dbo.MenuItemTypes");
            DropIndex("dbo.OrderedItems", new[] { "MenuItemTypeId" });
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderedItems", "MenuItemTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderedItems", "MenuItemTypeId");
        }
    }
}
