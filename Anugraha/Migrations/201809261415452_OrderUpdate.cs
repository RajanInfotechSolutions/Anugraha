namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anu_Order", "Anu_Order_URNNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anu_Order", "Anu_Order_URNNo");
        }
    }
}
