namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPropertiesAddedForOrderNPizzaAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Amount", c => c.Double(nullable: false));
            AddColumn("dbo.PizzaAttributes", "Amount", c => c.Double(nullable: false));
            AddColumn("dbo.PizzaAttributes", "Size", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PizzaAttributes", "Size");
            DropColumn("dbo.PizzaAttributes", "Amount");
            DropColumn("dbo.Orders", "Amount");
        }
    }
}
