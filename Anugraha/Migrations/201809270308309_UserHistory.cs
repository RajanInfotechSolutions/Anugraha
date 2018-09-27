namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserHistory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Anu_Log_History", "Anu_LAST_LOGGED_Out", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Anu_Log_History", "Anu_LAST_LOGGED_Out", c => c.DateTime(nullable: false));
        }
    }
}
