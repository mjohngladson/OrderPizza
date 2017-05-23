namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordderEntityChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Processed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Processed");
        }
    }
}
