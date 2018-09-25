namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stockupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Anu_Purchase_Detail", "Anu_Product_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Anu_Purchase_Detail", "Anu_Product_Id");
            AddForeignKey("dbo.Anu_Purchase_Detail", "Anu_Product_Id", "dbo.Products", "Anu_Product_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anu_Purchase_Detail", "Anu_Product_Id", "dbo.Products");
            DropIndex("dbo.Anu_Purchase_Detail", new[] { "Anu_Product_Id" });
            AlterColumn("dbo.Anu_Purchase_Detail", "Anu_Product_Id", c => c.String());
        }
    }
}
