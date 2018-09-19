namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Anu_Log_History",
                c => new
                    {
                        Anu_LogID = c.Int(nullable: false, identity: true),
                        Anu_LAST_LOGGED = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Anu_LogID);
            
            CreateTable(
                "dbo.Anu_User",
                c => new
                    {
                        Anu_USERID = c.Int(nullable: false, identity: true),
                        Anu_USERNAME = c.String(),
                        Anu_PASSWORD = c.String(),
                        Anu_CONFIRM_PASSWORD = c.String(),
                        Anu_MAC_ADDRESS = c.String(),
                        Anu_LogID = c.Int(nullable: false),
                        Anu_ISACTIVE = c.String(),
                    })
                .PrimaryKey(t => t.Anu_USERID)
                .ForeignKey("dbo.Anu_Log_History", t => t.Anu_LogID, cascadeDelete: true)
                .Index(t => t.Anu_LogID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Anu_User", "Anu_LogID", "dbo.Anu_Log_History");
            DropIndex("dbo.Anu_User", new[] { "Anu_LogID" });
            DropTable("dbo.Anu_User");
            DropTable("dbo.Anu_Log_History");
        }
    }
}
