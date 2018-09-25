namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anu_Category_Detail",
                c => new
                    {
                        Anu_Category_Id = c.String(nullable: false, maxLength: 128),
                        Anu_Category_Name = c.String(),
                        Anu_Category_Code = c.String(),
                        Anu_Category_IsActive = c.Boolean(nullable: false),
                        Anu_Category_CreatedBy = c.String(),
                        Anu_Category_CreatedDate = c.DateTime(nullable: false),
                        Anu_Category_ModifiedBy = c.String(),
                        Anu_Category_ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Anu_Category_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Anu_Product_Id = c.String(nullable: false, maxLength: 128),
                        Anu_Category_Id = c.String(maxLength: 128),
                        Anu_Product_Code = c.String(),
                        Anu_Product_Name = c.String(),
                        Anu_Product_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        type = c.Int(nullable: false),
                        Anu_Product_IsActive = c.Boolean(nullable: false),
                        Anu_Product_CreatedBy = c.String(),
                        Anu_Product_CreatedDate = c.DateTime(nullable: false),
                        Anu_Product_ModifiedBy = c.String(),
                        Anu_Product_ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Anu_Product_Id)
                .ForeignKey("dbo.Anu_Category_Detail", t => t.Anu_Category_Id)
                .Index(t => t.Anu_Category_Id);
            
            CreateTable(
                "dbo.Anu_Company_Detail",
                c => new
                    {
                        Anu_Company_Id = c.Int(nullable: false, identity: true),
                        Anu_Company_Name = c.String(),
                        Anu_Company_Owner = c.String(),
                        Anu_Company_Address1 = c.String(),
                        Anu_Company_Address2 = c.String(),
                        Anu_Company_City = c.String(),
                        Anu_Company_State = c.String(),
                        Anu_Company_PinCode = c.String(),
                        Anu_Company_MobileNo = c.String(),
                        Anu_Company_Landline = c.String(),
                        Anu_Company_Email = c.String(),
                        Anu_Company_IsActive = c.Boolean(nullable: false),
                        Anu_Company_CreatedBy = c.String(),
                        Anu_Company_CreatedDate = c.DateTime(nullable: false),
                        Anu_Company_ModifiedBy = c.String(),
                        Anu_Company_ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Anu_Company_Id);
            
            CreateTable(
                "dbo.Anu_User",
                c => new
                    {
                        Anu_USERID = c.Int(nullable: false, identity: true),
                        Anu_Company_Id = c.Int(nullable: false),
                        Anu_USERNAME = c.String(),
                        Anu_PASSWORD = c.String(),
                        Anu_CONFIRM_PASSWORD = c.String(),
                        Anu_MAC_ADDRESS = c.String(),
                        Anu_LogID = c.Int(nullable: false),
                        Anu_ISACTIVE = c.String(),
                    })
                .PrimaryKey(t => t.Anu_USERID)
                .ForeignKey("dbo.Anu_Company_Detail", t => t.Anu_Company_Id, cascadeDelete: true)
                .ForeignKey("dbo.Anu_Log_History", t => t.Anu_LogID, cascadeDelete: true)
                .Index(t => t.Anu_Company_Id)
                .Index(t => t.Anu_LogID);
            
            CreateTable(
                "dbo.Anu_Log_History",
                c => new
                    {
                        Anu_LogID = c.Int(nullable: false, identity: true),
                        Anu_LAST_LOGGED_In = c.DateTime(nullable: false),
                        Anu_LAST_LOGGED_Out = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Anu_LogID);
            
            CreateTable(
                "dbo.Anu_Vendor_Detail",
                c => new
                    {
                        Anu_Vendor_Id = c.String(nullable: false, maxLength: 128),
                        Anu_Vendor_Company_Name = c.String(),
                        Anu_Vendor_Company_Owner = c.String(),
                        Anu_Vendor_Company_Address1 = c.String(),
                        Anu_Vendor_Company_Address2 = c.String(),
                        Anu_Vendor_Company_City = c.String(),
                        Anu_Vendor_Company_State = c.String(),
                        Anu_Vendor_Company_PinCode = c.String(),
                        Anu_Vendor_Company_MobileNo = c.String(),
                        Anu_Vendor_Company_Landline = c.String(),
                        Anu_Vendor_Company_Email = c.String(),
                        Anu_Vendor_Company_GST = c.String(),
                        Anu_Vendor_Company_ACNO = c.String(),
                        Anu_Vendor_Company_IFSC = c.String(),
                        Anu_Vendor_IsActive = c.Boolean(nullable: false),
                        Anu_Vendor_CreatedBy = c.String(),
                        Anu_Vendor_CreatedDate = c.DateTime(nullable: false),
                        Anu_Vendor_ModifiedBy = c.String(),
                        Anu_Vendor_ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Anu_Vendor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anu_User", "Anu_LogID", "dbo.Anu_Log_History");
            DropForeignKey("dbo.Anu_User", "Anu_Company_Id", "dbo.Anu_Company_Detail");
            DropForeignKey("dbo.Products", "Anu_Category_Id", "dbo.Anu_Category_Detail");
            DropIndex("dbo.Anu_User", new[] { "Anu_LogID" });
            DropIndex("dbo.Anu_User", new[] { "Anu_Company_Id" });
            DropIndex("dbo.Products", new[] { "Anu_Category_Id" });
            DropTable("dbo.Anu_Vendor_Detail");
            DropTable("dbo.Anu_Log_History");
            DropTable("dbo.Anu_User");
            DropTable("dbo.Anu_Company_Detail");
            DropTable("dbo.Products");
            DropTable("dbo.Anu_Category_Detail");
        }
    }
}
