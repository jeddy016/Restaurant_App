namespace Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeOrderModelDiscountToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Discount", c => c.Decimal(nullable: false, precision: 7, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Discount", c => c.Int(nullable: false));
        }
    }
}
