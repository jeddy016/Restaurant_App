namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMenuItemAndType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MenuItemTypeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItemTypes", t => t.MenuItemTypeId, cascadeDelete: true)
                .Index(t => t.MenuItemTypeId);
            
            CreateTable(
                "dbo.MenuItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "MenuItemTypeId", "dbo.MenuItemTypes");
            DropIndex("dbo.MenuItems", new[] { "MenuItemTypeId" });
            DropTable("dbo.MenuItemTypes");
            DropTable("dbo.MenuItems");
        }
    }
}
