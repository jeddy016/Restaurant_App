namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createOrderedMenuItemsModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedMenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MenuItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.MenuItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedMenuItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderedMenuItems", "MenuItemId", "dbo.MenuItems");
            DropIndex("dbo.OrderedMenuItems", new[] { "MenuItemId" });
            DropIndex("dbo.OrderedMenuItems", new[] { "OrderId" });
            DropTable("dbo.OrderedMenuItems");
        }
    }
}
