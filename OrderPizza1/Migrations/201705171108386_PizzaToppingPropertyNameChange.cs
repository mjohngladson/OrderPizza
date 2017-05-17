namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PizzaToppingPropertyNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizzas", "Topping", c => c.Int(nullable: false));
            AlterColumn("dbo.Pizzas", "Size", c => c.Int(nullable: false));
            AlterColumn("dbo.Pizzas", "Crust", c => c.Int(nullable: false));
            DropColumn("dbo.Pizzas", "Toppings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pizzas", "Toppings", c => c.String());
            AlterColumn("dbo.Pizzas", "Crust", c => c.String());
            AlterColumn("dbo.Pizzas", "Size", c => c.String());
            DropColumn("dbo.Pizzas", "Topping");
        }
    }
}
