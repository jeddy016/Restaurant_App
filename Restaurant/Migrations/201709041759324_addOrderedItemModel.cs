namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderedItemModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderedItems", new[] { "OrderId" });
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            DropTable("dbo.OrderedItems");
        }
    }
}
