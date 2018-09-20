namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Company : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Anu_User", "Anu_Company_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Anu_User", "Anu_Company_Id");
            AddForeignKey("dbo.Anu_User", "Anu_Company_Id", "dbo.Anu_Company_Detail", "Anu_Company_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anu_User", "Anu_Company_Id", "dbo.Anu_Company_Detail");
            DropIndex("dbo.Anu_User", new[] { "Anu_Company_Id" });
            DropColumn("dbo.Anu_User", "Anu_Company_Id");
            DropTable("dbo.Anu_Company_Detail");
        }
    }
}
