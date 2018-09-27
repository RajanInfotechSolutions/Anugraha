namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Anu_User", "Anu_ISACTIVE", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Anu_User", "Anu_ISACTIVE", c => c.String());
        }
    }
}
