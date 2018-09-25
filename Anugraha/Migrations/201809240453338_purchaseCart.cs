namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchaseCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anu_Purchase_Cart",
                c => new
                    {
                        Anu_CartId = c.Int(nullable: false, identity: true),
                        Anu_ProductId = c.String(),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Anu_CartId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Anu_Purchase_Cart");
        }
    }
}
