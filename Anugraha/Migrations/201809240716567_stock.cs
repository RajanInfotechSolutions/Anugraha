namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anu_Stock_Detail",
                c => new
                    {
                        Anu_Stock_Detail_Id = c.Int(nullable: false, identity: true),
                        Anu_StockId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Anu_Stock_Detail_Id)
                .ForeignKey("dbo.Anu_Stock", t => t.Anu_StockId, cascadeDelete: true)
                .Index(t => t.Anu_StockId);
            
            CreateTable(
                "dbo.Anu_Stock",
                c => new
                    {
                        Anu_StockId = c.Int(nullable: false, identity: true),
                        Anu_Product_Id = c.String(maxLength: 128),
                        Anu_Stock_Product_Code = c.String(),
                        Anu_Stock_Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Anu_StockId)
                .ForeignKey("dbo.Products", t => t.Anu_Product_Id)
                .Index(t => t.Anu_Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anu_Stock_Detail", "Anu_StockId", "dbo.Anu_Stock");
            DropForeignKey("dbo.Anu_Stock", "Anu_Product_Id", "dbo.Products");
            DropIndex("dbo.Anu_Stock", new[] { "Anu_Product_Id" });
            DropIndex("dbo.Anu_Stock_Detail", new[] { "Anu_StockId" });
            DropTable("dbo.Anu_Stock");
            DropTable("dbo.Anu_Stock_Detail");
        }
    }
}
