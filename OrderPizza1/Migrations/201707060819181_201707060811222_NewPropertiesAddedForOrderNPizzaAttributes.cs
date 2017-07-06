namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201707060811222_NewPropertiesAddedForOrderNPizzaAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PizzaAttributes", "Amount", c => c.Double());
            AlterColumn("dbo.PizzaAttributes", "Size", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PizzaAttributes", "Size", c => c.Int(nullable: false));
            AlterColumn("dbo.PizzaAttributes", "Amount", c => c.Double(nullable: false));
        }
    }
}
