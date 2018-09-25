namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anu_Cart",
                c => new
                    {
                        Anu_Cart_Id = c.Int(nullable: false, identity: true),
                        Anu_Product_Id = c.String(maxLength: 128),
                        Anu_cart_Qty = c.String(),
                        Anu_cart_Type = c.Int(nullable: false),
                        Anu_cart_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Anu_Cart_Id)
                .ForeignKey("dbo.Products", t => t.Anu_Product_Id)
                .Index(t => t.Anu_Product_Id);
            
            AddColumn("dbo.Anu_Order_Detail", "Anu_Order_Detail_Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Anu_Order_Detail", "Anu_Product_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Anu_Order_Detail", "Anu_Product_Id");
            AddForeignKey("dbo.Anu_Order_Detail", "Anu_Product_Id", "dbo.Products", "Anu_Product_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anu_Order_Detail", "Anu_Product_Id", "dbo.Products");
            DropForeignKey("dbo.Anu_Cart", "Anu_Product_Id", "dbo.Products");
            DropIndex("dbo.Anu_Order_Detail", new[] { "Anu_Product_Id" });
            DropIndex("dbo.Anu_Cart", new[] { "Anu_Product_Id" });
            AlterColumn("dbo.Anu_Order_Detail", "Anu_Product_Id", c => c.String());
            DropColumn("dbo.Anu_Order_Detail", "Anu_Order_Detail_Type");
            DropTable("dbo.Anu_Cart");
        }
    }
}
