namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeOrderedItems : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedItems", "MenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderedItems", new[] { "MenuItemId" });
            DropIndex("dbo.OrderedItems", new[] { "OrderId" });
            DropTable("dbo.OrderedItems");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrderedItems", "OrderId");
            CreateIndex("dbo.OrderedItems", "MenuItemId");
            AddForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderedItems", "MenuItemId", "dbo.MenuItems", "Id", cascadeDelete: true);
        }
    }
}
