namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderedItemModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuItemId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.MenuItemId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderedItems", "MenuItemId", "dbo.MenuItems");
            DropIndex("dbo.OrderedItems", new[] { "OrderId" });
            DropIndex("dbo.OrderedItems", new[] { "MenuItemId" });
            DropTable("dbo.OrderedItems");
        }
    }
}
