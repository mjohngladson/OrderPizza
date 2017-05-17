namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataTypeChangedForPizzaTopping : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pizzas", "Topping");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pizzas", "Topping", c => c.Int(nullable: false));
        }
    }
}
