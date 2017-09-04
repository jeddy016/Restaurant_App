namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeOrderedItemModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders");
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
                        OrderId = c.Int(nullable: false),
                        MenuItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrderedItems", "OrderId");
            AddForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
