namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anu_Order_Detail",
                c => new
                    {
                        Anu_Order_Detail_Id = c.String(nullable: false, maxLength: 128),
                        Anu_Order_Id = c.String(maxLength: 128),
                        Anu_Product_Id = c.String(),
                        Anu_Order_Detail_Qty = c.String(),
                        Anu_Order_Detail_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anu_Order_Detail_Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anu_Order_Detail_Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anu_Order_Detail_ReceivedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anu_Order_Detail_RemainingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Anu_Order_Detail_Id)
                .ForeignKey("dbo.Anu_Order", t => t.Anu_Order_Id)
                .Index(t => t.Anu_Order_Id);
            
            CreateTable(
                "dbo.Anu_Order",
                c => new
                    {
                        Anu_Order_Id = c.String(nullable: false, maxLength: 128),
                        Anu_Order_OrderDate = c.DateTime(nullable: false),
                        Anu_Order_TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Anu_Order_TotalQty = c.Int(nullable: false),
                        Anu_Order_Mode = c.Int(nullable: false),
                        Anu_Order_Status = c.Int(nullable: false),
                        Anu_Order_IsActive = c.Boolean(nullable: false),
                        Anu_Order_Createdby = c.String(),
                        Anu_Order_CreatedDate = c.DateTime(nullable: false),
                        Anu_Order_ModifiedBy = c.String(),
                        Anu_Order_ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Anu_Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anu_Order_Detail", "Anu_Order_Id", "dbo.Anu_Order");
            DropIndex("dbo.Anu_Order_Detail", new[] { "Anu_Order_Id" });
            DropTable("dbo.Anu_Order");
            DropTable("dbo.Anu_Order_Detail");
        }
    }
}
