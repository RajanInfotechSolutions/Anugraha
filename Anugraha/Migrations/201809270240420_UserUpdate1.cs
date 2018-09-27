namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anu_User", "Anu_Company_Id", "dbo.Anu_Company_Detail");
            DropIndex("dbo.Anu_User", new[] { "Anu_Company_Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Anu_User", "Anu_Company_Id");
            AddForeignKey("dbo.Anu_User", "Anu_Company_Id", "dbo.Anu_Company_Detail", "Anu_Company_Id", cascadeDelete: true);
        }
    }
}
