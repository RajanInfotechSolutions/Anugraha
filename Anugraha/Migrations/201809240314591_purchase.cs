namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anu_Purchase_Detail",
                c => new
                    {
                        Anu_Purchase_Detail_Id = c.String(nullable: false, maxLength: 128),
                        Anu_Purchase_Id = c.String(maxLength: 128),
                        Anu_Product_Id = c.String(),
                        Anu_Purchase_Detail_Qty = c.String(),
                        Anu_Purchase_Detail_type = c.Int(nullable: false),
                        Anu_Purchase_Detail_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Anu_Purchase_Detail_Id)
                .ForeignKey("dbo.Anu_Purchase", t => t.Anu_Purchase_Id)
                .Index(t => t.Anu_Purchase_Id);
            
            CreateTable(
                "dbo.Anu_Purchase",
                c => new
                    {
                        Anu_Purchase_Id = c.String(nullable: false, maxLength: 128),
                        Anu_Purchase_InvoiceNo = c.String(),
                        Anu_Vendor_Id = c.String(maxLength: 128),
                        Anu_Purchase_Invoice_Date = c.DateTime(nullable: false),
                        Anu_Purchase_Quantity = c.Int(nullable: false),
                        Anu_Purchase_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        Anu_Purchase_IsActive = c.Boolean(nullable: false),
                        Anu_Purchase_CreatedBy = c.String(),
                        Anu_Purchase_CreatedDate = c.DateTime(nullable: false),
                        Anu_Purchase_ModifiedBy = c.String(),
                        Anu_Purchase_ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Anu_Purchase_Id)
                .ForeignKey("dbo.Anu_Vendor_Detail", t => t.Anu_Vendor_Id)
                .Index(t => t.Anu_Vendor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anu_Purchase", "Anu_Vendor_Id", "dbo.Anu_Vendor_Detail");
            DropForeignKey("dbo.Anu_Purchase_Detail", "Anu_Purchase_Id", "dbo.Anu_Purchase");
            DropIndex("dbo.Anu_Purchase", new[] { "Anu_Vendor_Id" });
            DropIndex("dbo.Anu_Purchase_Detail", new[] { "Anu_Purchase_Id" });
            DropTable("dbo.Anu_Purchase");
            DropTable("dbo.Anu_Purchase_Detail");
        }
    }
}
