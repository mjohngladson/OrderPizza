namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadePizzaAttributeColumnsNonNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PizzaAttributes", "Amount", c => c.Double(nullable: false));
            AlterColumn("dbo.PizzaAttributes", "Size", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PizzaAttributes", "Size", c => c.Int());
            AlterColumn("dbo.PizzaAttributes", "Amount", c => c.Double());
        }
    }
}
