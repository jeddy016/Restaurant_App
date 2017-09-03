namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServerIdToOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Server_Id", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "Server_Id" });
            RenameColumn(table: "dbo.Orders", name: "Server_Id", newName: "ServerId");
            AlterColumn("dbo.Orders", "ServerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "ServerId");
            AddForeignKey("dbo.Orders", "ServerId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ServerId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "ServerId" });
            AlterColumn("dbo.Orders", "ServerId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "ServerId", newName: "Server_Id");
            CreateIndex("dbo.Orders", "Server_Id");
            AddForeignKey("dbo.Orders", "Server_Id", "dbo.Users", "Id");
        }
    }
}
