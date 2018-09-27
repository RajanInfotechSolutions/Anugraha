namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Anu_User", "Anu_LogID", "dbo.Anu_Log_History");
            DropIndex("dbo.Anu_User", new[] { "Anu_LogID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Anu_User", "Anu_LogID");
            AddForeignKey("dbo.Anu_User", "Anu_LogID", "dbo.Anu_Log_History", "Anu_LogID", cascadeDelete: true);
        }
    }
}
