namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate123 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Anu_User", "Anu_MAC_ADDRESS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Anu_User", "Anu_MAC_ADDRESS", c => c.String());
        }
    }
}
