namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchaseCartupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anu_Purchase_Cart", "Anu_Product_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Anu_Purchase_Cart", "Anu_Product_Id");
            AddForeignKey("dbo.Anu_Purchase_Cart", "Anu_Product_Id", "dbo.Products", "Anu_Product_Id");
            DropColumn("dbo.Anu_Purchase_Cart", "Anu_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Anu_Purchase_Cart", "Anu_ProductId", c => c.String());
            DropForeignKey("dbo.Anu_Purchase_Cart", "Anu_Product_Id", "dbo.Products");
            DropIndex("dbo.Anu_Purchase_Cart", new[] { "Anu_Product_Id" });
            DropColumn("dbo.Anu_Purchase_Cart", "Anu_Product_Id");
        }
    }
}
