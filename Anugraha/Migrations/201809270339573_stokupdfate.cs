namespace Anugraha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stokupdfate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Anu_Stock", "Anu_Stock_Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Anu_Stock", "Anu_Stock_Type");
        }
    }
}
